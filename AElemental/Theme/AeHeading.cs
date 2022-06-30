namespace AElemental.Theme;

public partial class AeTheme
{
    [AeCssVariable] public string AeHeadingMargin { get; set; } = "0px 0px 0.35em;";
    
    [AeCssVariable] public string AeH1FontSize { get; set; } = AeHeadingFontSizes.H1;
    [AeCssVariable] public string AeH2FontSize { get; set; } = AeHeadingFontSizes.H2;
    [AeCssVariable] public string AeH3FontSize { get; set; } = AeHeadingFontSizes.H3;
    [AeCssVariable] public string AeH4FontSize { get; set; } = AeHeadingFontSizes.H4;
    [AeCssVariable] public string AeH5FontSize { get; set; } = AeHeadingFontSizes.H5;
    [AeCssVariable] public string AeH6FontSize { get; set; } = AeHeadingFontSizes.H6;
    
    [AeCssVariable] public string AeH1FontWeight { get; set; } = AeHeadingFontWeights.H1;
    [AeCssVariable] public string AeH2FontWeight { get; set; } = AeHeadingFontWeights.H2;
    [AeCssVariable] public string AeH3FontWeight { get; set; } = AeHeadingFontWeights.H3;
    [AeCssVariable] public string AeH4FontWeight { get; set; } = AeHeadingFontWeights.H4;
    [AeCssVariable] public string AeH5FontWeight { get; set; } = AeHeadingFontWeights.H5;
    [AeCssVariable] public string AeH6FontWeight { get; set; } = AeHeadingFontWeights.H6;
    
    [AeCssVariable] public string AeH1LineHeight { get; set; } = AeHeadingLineHeights.H1;
    [AeCssVariable] public string AeH2LineHeight { get; set; } = AeHeadingLineHeights.H2;
    [AeCssVariable] public string AeH3LineHeight { get; set; } = AeHeadingLineHeights.H3;
    [AeCssVariable] public string AeH4LineHeight { get; set; } = AeHeadingLineHeights.H4;
    [AeCssVariable] public string AeH5LineHeight { get; set; } = AeHeadingLineHeights.H5;
    [AeCssVariable] public string AeH6LineHeight { get; set; } = AeHeadingLineHeights.H6;
}


public static class AeHeadingFontSizes
{
    public static readonly string H1 = "6rem";
    public static readonly string H2 = "3.75rem";
    public static readonly string H3 = "3rem";
    public static readonly string H4 = "2.125rem";
    public static readonly string H5 = "1.5rem";
    public static readonly string H6 = "1.25rem";
}

public static class AeHeadingLineHeights
{
    public static readonly string H1 = "1.167";
    public static readonly string H2 = "1.2";
    public static readonly string H3 = "1.167";
    public static readonly string H4 = "1.235";
    public static readonly string H5 = "1.334";
    public static readonly string H6 = "1.6";
}

public static class AeHeadingFontWeights
{
    public static readonly string H1 = "300";
    public static readonly string H2 = "300";
    public static readonly string H3 = "400";
    public static readonly string H4 = "400";
    public static readonly string H5 = "400";
    public static readonly string H6 = "500";
}