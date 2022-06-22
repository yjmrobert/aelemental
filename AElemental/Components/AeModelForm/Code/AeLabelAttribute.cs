using System;

namespace AElemental.Components;

public class AeLabelAttribute : Attribute
{
    private readonly int _order;


    public AeLabelAttribute(string label = null, string placeholder = null, int order = 0, int size = 0,
        string[] validValues = null, bool isDropDown = false, string row = null, string column = null,
        bool isPasswordField = false)
    {
        Label = label;
        _order = order;
        InputLength = size;
        ValidValues = validValues;
        IsDropDown = isDropDown;
        if (size == 0)
            InputLength = null;
        PlaceHolder = placeholder;
        Row = row;
        Column = column;
        IsPasswordField = isPasswordField;
    }

    public virtual string Label { get; }

    public virtual string PlaceHolder { get; }

    public virtual int? Order => _order;


    public virtual int? InputLength { get; }

    public virtual string[] ValidValues { get; }

    public virtual bool IsDropDown { get; }

    public virtual string Row { get; }

    public virtual string Column { get; }

    public virtual bool IsPasswordField { get; }
}