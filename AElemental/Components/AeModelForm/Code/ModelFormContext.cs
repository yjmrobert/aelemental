using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;

namespace AElemental.Components;

public class ModelFormArgsInternal
{
    public PropertyInfo PropertyInfo { get; set; }
    public EditContext EditContext { get; set; }

    public bool HasPropertyChanged<T>(Expression<Func<T, object>> expression)
    {
        return AeModelFormTools.WithPropertyExpression(expression) == PropertyInfo;
    }
}

public class ModelFormChangeArgs
{
    public PropertyInfo PropertyInfo { get; set; }
    public EditContext EditContext { get; set; }

    public IModelFormContext Context { get; set; }

    public bool HasPropertyChanged<T>(Expression<Func<T, object>> expression)
    {
        return AeModelFormTools.WithPropertyExpression(expression) == PropertyInfo;
    }
}

public class ModelFormContext<T> : IModelFormContext
{
    private Func<T, Dictionary<string, List<string>>>? _validator;
    private readonly Dictionary<string, string> categoryNotes = new();
    private readonly Dictionary<PropertyInfo, string> fieldNotes = new();
    private Dictionary<PropertyInfo, (Delegate Label, Delegate Choices, Delegate onChange)> optionProperties = new();

    private Dictionary<PropertyInfo, (AeDropdownPropertyInput<T> component, Action updateOptions)>
        optionPropertyComponent = new();

    private Dictionary<PropertyInfo, bool> propertyVisibility = new();
    internal ILogger? Logger { get; set; }
    public Func<Task> RefreshModel { get; set; }
    public List<PropertyInfo> Properties { get; private set; }

    public bool CustomValidation => _validator != null;

    public List<string> LockedCategories { get; } = new();


    public bool IsCategoryLocked(string category)
    {
        return LockedCategories.Contains(category);
    }

    public void RegisterCategoryLock(string category, bool isLocked)
    {
        if (isLocked && !LockedCategories.Contains(category)) LockedCategories.Add(category);

        if (!isLocked && LockedCategories.Contains(category)) LockedCategories.Remove(category);
    }

    public string GetFieldNote(PropertyInfo propertyInfo)
    {
        if (fieldNotes.ContainsKey(propertyInfo)) return fieldNotes[propertyInfo];
        return string.Empty;
    }

    public string GetCategoryNote(string category)
    {
        if (categoryNotes.ContainsKey(category)) return categoryNotes[category];
        return string.Empty;
    }

    public void RegisterCategoryNotes(string category, string notes)
    {
        if (categoryNotes.ContainsKey(category)) categoryNotes.Remove(category);
        categoryNotes.Add(category, notes);
    }

    public void RegisterFieldNotes<P>(Expression<Func<P, string>> propertyPath, string notes)
    {
        var propertyInfo = GetPropertyInfo(propertyPath);
        if (fieldNotes.ContainsKey(propertyInfo)) fieldNotes.Remove(propertyInfo);
        fieldNotes.Add(propertyInfo, notes);
    }

    public void RegisterOptionValueProperty(PropertyInfo property, Func<IEnumerable<string>> choices,
        Action<string> onChange = null)
    {
        RegisterOptionValueProperty(property, e => e, choices, onChange);
    }

    public void RegisterOptionValueProperty<P>(Expression<Func<P, string>> propertyPath,
        Func<IEnumerable<string>> choices, Action<string> onChange = null)
    {
        RegisterOptionValueProperty(GetPropertyInfo(propertyPath), e => e, choices, onChange);
    }

    public void RegisterOptionValueProperty<P1, P2>(Expression<Func<P1, P2>> propertyPath, Func<P2, string> label,
        Func<IEnumerable<P2>> choices, Action<P2> onChange = null)
    {
        RegisterOptionValueProperty(GetPropertyInfo(propertyPath), label, choices, onChange);
    }

    public void OnOptionPropertyChange(PropertyInfo property, object newValue)
    {
        if (optionProperties.TryGetValue(property, out var delegates)) delegates.onChange?.DynamicInvoke(newValue);
    }


    public bool IsDropDown(PropertyInfo propertyInfo)
    {
        var hasValidValues = Attribute.IsDefined(propertyInfo, typeof(AeLabelAttribute))
            ? (Attribute.GetCustomAttribute(propertyInfo, typeof(AeLabelAttribute)) as AeLabelAttribute).ValidValues
            ?.Length > 0
            : optionProperties.ContainsKey(propertyInfo);
        var hasDropDown = Attribute.IsDefined(propertyInfo, typeof(AeLabelAttribute))
            ? (Attribute.GetCustomAttribute(propertyInfo, typeof(AeLabelAttribute)) as AeLabelAttribute).IsDropDown
            : false;
        return hasValidValues || hasDropDown;
    }

    public string? GetDisplayValue(PropertyInfo propertyInfo, object item)
    {
        var currentValue = propertyInfo.GetValue(item);
        if (optionProperties.TryGetValue(propertyInfo, out var accessors))
            return accessors.Label.DynamicInvoke(currentValue) as string;
        return currentValue?.ToString();
    }

    public void RefreshOptions(PropertyInfo propertyInfo)
    {
        if (optionPropertyComponent.TryGetValue(propertyInfo, out var component)) component.updateOptions?.Invoke();
    }

    public void RefreshOptions<T1>(Expression<Func<T1, object>> propertyPath)
    {
        RefreshOptions(GetPropertyInfo(propertyPath));
    }

    public (List<object> values, List<string> labels) GetOptionValuesForProperty(PropertyInfo propertyInfo)
    {
        if (optionProperties.TryGetValue(propertyInfo, out var accessors))
        {
            var validValues = accessors.Choices.DynamicInvoke() as IEnumerable;
            if (validValues == null) return (null, null);
            var displayValues = new List<string>();
            var values = new List<object>();
            foreach (var item in validValues)
            {
                values.Add(item);
                displayValues.Add(accessors.Label.DynamicInvoke(item) as string);
            }

            return (values, displayValues);
        }

        var dropdownValues = propertyInfo.DropdownValues()?.ToList();
        if (dropdownValues is null)
            Logger?.LogWarning($"Property {propertyInfo.Name} doesn't have any values for dropdown");
        return (dropdownValues?.Cast<object>()?.ToList() ?? new List<object>(), dropdownValues ?? new List<string>());
    }

    public void Clear()
    {
        RefreshModel = null;
        Properties = null;
        optionProperties = null;
        optionPropertyComponent = null;
        propertyVisibility = null;
    }

    public PropertyInfo GetProperty(string name)
    {
        return Properties.Single(p => string.Equals(p.Name, name, StringComparison.InvariantCultureIgnoreCase));
    }


    public void SetVisible<T1>(Expression<Func<T1, object>> propertyPath, bool isVisible)
    {
        SetVisible(GetPropertyInfo(propertyPath), isVisible);
    }

    public void SetVisible(PropertyInfo property, bool isVisible)
    {
        if (!propertyVisibility.TryAdd(property, isVisible))
            propertyVisibility[property] = isVisible;
    }

    public void SetValidator<T1>(Func<T1, Dictionary<string, List<string>>> validator)
    {
        _validator = (Func<T, Dictionary<string, List<string>>>) Convert.ChangeType(validator,
            typeof(Func<T1, Dictionary<string, List<string>>>));
    }

    public List<(string category, List<List<PropertyInfo>> properties)> GetCategories()
    {
        return typeof(T).GetAeModelFormCategories().Select(elem => (elem.category,
                visibleProperties: elem.properties.Select(l => l.Where(l => IsVisible(l)).ToList()).ToList()))
            .Where(p => p.visibleProperties.Any(l => l.Count > 0)).ToList();
    }

    public void RegisterOptionValueProperty(Expression<Func<T, string>> propertyPath, Func<IEnumerable<string>> choices,
        Action<string> onChange = null)
    {
        RegisterOptionValueProperty<string>(propertyPath, e => e, choices, onChange);
    }

    private static PropertyInfo GetPropertyInfo(LambdaExpression expression)
    {
        return AeModelFormTools.WithPropertyExpression(expression);
    }

    public void RegisterOptionValueProperty<S>(Expression<Func<T, S>> propertyPath, Func<S, string> label,
        Func<IEnumerable<S>> choices, Action<S> onChange = null)
    {
        RegisterOptionValueProperty(GetPropertyInfo(propertyPath), label, choices, onChange);
    }

    public void RegisterOptionValueProperty<S>(PropertyInfo property, Func<S, string> label,
        Func<IEnumerable<S>> choices, Action<S> onChange = null)
    {
        if (property is null) throw new ArgumentNullException(nameof(property));

        if (label is null) throw new ArgumentNullException(nameof(label));

        if (choices is null) throw new ArgumentNullException(nameof(choices));

        if (optionProperties.ContainsKey(property)) optionProperties.Remove(property);

        optionProperties.Add(property, (label, choices, onChange));
    }


    public static Type[] GetDelegateParameterTypes(MethodInfo invoke)
    {
        var parameters = invoke.GetParameters();
        var typeParameters = new Type[parameters.Length];
        for (var i = 0; i < parameters.Length; i++) typeParameters[i] = parameters[i].ParameterType;
        return typeParameters;
    }

    public static Type GetDelegateReturnType(MethodInfo invoke)
    {
        return invoke.ReturnType;
    }

    public void RegisterOptionComponent(PropertyInfo propertyInfo, AeDropdownPropertyInput<T> aeDropdown,
        Action updateOptions)
    {
        if (!optionPropertyComponent.TryAdd(propertyInfo, (aeDropdown, updateOptions)))
            optionPropertyComponent[propertyInfo] = (aeDropdown, updateOptions);
    }

    public void RefreshOptions<S>(Expression<Func<T, S>> propertyPath)
    {
        RefreshOptions(GetPropertyInfo(propertyPath));
    }

    public void SetProperties(List<PropertyInfo> properties)
    {
        Properties = properties;
    }

    public bool IsVisible(PropertyInfo property)
    {
        if (propertyVisibility.TryGetValue(property, out var isVisible)) return isVisible;
        return true;
    }

    public Dictionary<string, List<string>> Validate(T model)
    {
        return _validator is null
            ? new Dictionary<string, List<string>>()
            : _validator(model);
    }
}