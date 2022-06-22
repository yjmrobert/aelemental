using System.Collections.Generic;

namespace AElemental.FormBuilder;

public enum FormFieldType
{
    Text,
    Integer,
    Decimal,
    Boolean,
    Dropdown,
    Date,
    Time,
    Money
}

public static class FormFieldTypeReference
{
    public static readonly EnumIndexedArray<FormFieldType, string> EFTypes = new()
    {
        {FormFieldType.Text, "string"},
        {FormFieldType.Integer, "int"},
        {FormFieldType.Decimal, "double"},
        {FormFieldType.Boolean, "bool"},
        {FormFieldType.Dropdown, "string"},
        {FormFieldType.Date, "DateTime"},
        {FormFieldType.Time, "DateTime"},
        {FormFieldType.Money, "double"}
    };

    public static readonly Dictionary<string, string> EFTypesStr = new()
    {
        {"Text", "string"},
        {"Integer", "int"},
        {"Decimal", "double"},
        {"Boolean", "bool"},
        {"Dropdown", "string"},
        {"Date", "DateTime"},
        {"Time", "DateTime"},
        {"Money", "double"}
    };

    public static readonly EnumIndexedArray<FormFieldType, string> Annotations = new()
    {
        {FormFieldType.Money, "[Column(TypeName=\"Money\")]"}
    };

    public static readonly Dictionary<string, string> AnnotationsStr = new()
    {
        {"Money", "[Column(TypeName=\"Money\")]"}
    };
}