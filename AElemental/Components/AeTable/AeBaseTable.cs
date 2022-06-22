using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AElemental.Code;
using Microsoft.AspNetCore.Components;

namespace AElemental.Components;

public class AeBaseTable<T> : HtmlElement
{
    protected (int column, bool sortAscending) _sorting = (0, true);
    [Parameter] public List<string> Headers { get; set; } = new();
    [Parameter] public List<T> Dataset { get; set; }
    [Parameter] public List<Func<T, string>> Accessors { get; set; }
    [Parameter] public List<CustomRowComparer<T>> Sorters { get; set; }
    [Parameter] public string GridTemplateColumns { get; set; }
    [Parameter] public List<Func<T, RenderFragment>> Renderers { get; set; }
    [Parameter] public EventCallback<T> OnRowClick { get; set; }
    [Parameter] public EventCallback<T> OnRowFocus { get; set; }
    [Parameter] public Func<string, int, RenderFragment> CustomHeader { get; set; }
    [Parameter] public bool DisableFirstSort { get; set; }

    protected IEnumerable<T> Rows => GetSortedDataset();


    protected string _tableClass => $"ae table {_inputClass}";
    protected string _gridStyle => $"grid-template-columns: {CalculateGridTemplateColumns()};";

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

    protected virtual IEnumerable<T> GetSortedDataset()
    {
        if (Dataset is null || !Dataset.Any()) return new List<T>();

        if (DisableFirstSort)
        {
            //The default sort should only be run when the table loads the first time.
            DisableFirstSort = false;
            return Dataset;
        }

        if (_sorting.sortAscending)
            // if Sorter Parameters exist, use sorter functions, else use Accessors TableComparer
            return Sorters != null && Sorters[_sorting.column] != null
                ? Dataset.OrderBy(data => data, Sorters[_sorting.column])
                : Dataset.OrderBy(data => Accessors[_sorting.column].Invoke(data));
        return Sorters != null && Sorters[_sorting.column] != null
            ? Dataset.OrderByDescending(data => data, Sorters[_sorting.column])
            : Dataset.OrderByDescending(data => Accessors[_sorting.column].Invoke(data));
    }

    protected virtual string CalculateGridTemplateColumns()
    {
        if (string.IsNullOrWhiteSpace(GridTemplateColumns)) return $"repeat({Accessors?.Count ?? 1}, 1fr)";

        return GridTemplateColumns;
    }

    protected virtual void ToggleSortOnColumn(int column)
    {
        if (column == _sorting.column)
        {
            _sorting.sortAscending = !_sorting.sortAscending;
        }
        else
        {
            _sorting.column = column;
            _sorting.sortAscending = true;
        }

        StateHasChanged();
    }

    protected virtual string GetSortIconClass(int column)
    {
        if (column == _sorting.column) return _sorting.sortAscending ? "fad fa-sort-down" : "fad fa-sort-up";
        return "fad fa-sort";
    }

    // It's not recommended to use the RenderFragment builder yet so this is a catch-all workaround
    protected virtual RenderFragment DefaultHeader(string header, int index)
    {
        throw new NotImplementedException("You must implement the DefaultHeader method for your Table Component.");
    }

    protected virtual byte[] ExportToCSVInByte()
    {
        var builder = new StringBuilder();
        (int column, bool sortAscending) _sorting = (0, true);

        foreach (var h in Headers) builder.Append(h + ",");
        //Remove the last ,
        builder.Length--;
        builder.Append(Environment.NewLine);

        foreach (var row in Sorters != null && Sorters[_sorting.column] != null
                     ? Dataset.OrderByDescending(data => data, Sorters[_sorting.column])
                     : Dataset.OrderByDescending(data => Accessors[_sorting.column].Invoke(data)))
        {
            foreach (var (accessor, index) in Accessors.Select((a, i) => (a, i)))
            {
                var value = accessor?.Invoke(row);
                if (value.IndexOfAny(new[] {'"', ','}) != -1)
                {
                    builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                    builder.Append(",");
                }
                else
                {
                    builder.Append(accessor?.Invoke(row) + ",");
                }
            }

            //Remove the last ,
            builder.Length--;
            builder.Append(Environment.NewLine);
        }

        var bytes = Encoding.UTF8.GetBytes(builder.ToString());
        return bytes;
    }
}