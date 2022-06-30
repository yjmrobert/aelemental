namespace AElemental.Theme;

public partial class AeTheme
{
    [AeCssVariable] public string AeBoxShadow0 { get; set; } = AeBoxShadows.BoxShadow0;
    [AeCssVariable] public string AeBoxShadow1 { get; set; } = AeBoxShadows.BoxShadow1;
    [AeCssVariable] public string AeBoxShadow2 { get; set; } = AeBoxShadows.BoxShadow2;
    [AeCssVariable] public string AeBoxShadow3 { get; set; } = AeBoxShadows.BoxShadow3;
    [AeCssVariable] public string AeBoxShadow4 { get; set; } = AeBoxShadows.BoxShadow4;
    [AeCssVariable] public string AeBoxShadow5 { get; set; } = AeBoxShadows.BoxShadow5;
}

public static class AeBoxShadows
{
    public static readonly string BoxShadow0 = "none;";
    public static readonly string BoxShadow1 = "0 1px 3px rgba(0, 0, 0, 0.02), 0 1px 2px rgba(0, 0, 0, 0.14);";
    public static readonly string BoxShadow2 = "0 3px 6px rgba(0, 0, 0, 0.06), 0 3px 6px rgba(0, 0, 0, 0.13);";
    public static readonly string BoxShadow3 = "0 10px 20px rgba(0, 0, 0, 0.09), 0 6px 6px rgba(0, 0, 0, 0.13);";
    public static readonly string BoxShadow4 = "0 14px 28px rgba(0, 0, 0, 0.15), 0 10px 10px rgba(0, 0, 0, 0.12);";
    public static readonly string BoxShadow5 = "0 19px 38px rgba(0, 0, 0, 0.20), 0 15px 12px rgba(0, 0, 0, 0.12);";
}