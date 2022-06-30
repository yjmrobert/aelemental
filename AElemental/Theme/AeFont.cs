namespace AElemental.Theme;

public partial class AeTheme
{
    [AeCssVariable] public string AeHeadingMargin { get; set; } = "0px 0px 0.35em;";
    [AeCssVariable] public string AeFontFamily { get; set; } = "Roboto, sans-serif";
    
    [AeCssVariable] public string AeH1FontSize { get; set; } = AeFontSizes.H1;
    [AeCssVariable] public string AeH2FontSize { get; set; } = AeFontSizes.H2;
    [AeCssVariable] public string AeH3FontSize { get; set; } = AeFontSizes.H3;
    [AeCssVariable] public string AeH4FontSize { get; set; } = AeFontSizes.H4;
    [AeCssVariable] public string AeH5FontSize { get; set; } = AeFontSizes.H5;
    [AeCssVariable] public string AeH6FontSize { get; set; } = AeFontSizes.H6;
    
    [AeCssVariable] public string AeSubtitleFontSize { get; set; } = AeFontSizes.Subtitle;
    [AeCssVariable] public string AeTextFontSize { get; set; } = AeFontSizes.Text;
    [AeCssVariable] public string AeParagraphFontSize { get; set; } = AeFontSizes.Paragraph;
    [AeCssVariable] public string AeOverlineFontSize { get; set; } = AeFontSizes.Overline;

    
    [AeCssVariable] public string AeH1FontWeight { get; set; } = AeFontWeights.H1;
    [AeCssVariable] public string AeH2FontWeight { get; set; } = AeFontWeights.H2;
    [AeCssVariable] public string AeH3FontWeight { get; set; } = AeFontWeights.H3;
    [AeCssVariable] public string AeH4FontWeight { get; set; } = AeFontWeights.H4;
    [AeCssVariable] public string AeH5FontWeight { get; set; } = AeFontWeights.H5;
    [AeCssVariable] public string AeH6FontWeight { get; set; } = AeFontWeights.H6;
    
    [AeCssVariable] public string AeSubtitleFontWeight { get; set; } = AeFontWeights.Subtitle;
    [AeCssVariable] public string AeTextFontWeight { get; set; } = AeFontWeights.Text;
    [AeCssVariable] public string AeParagraphFontWeight { get; set; } = AeFontWeights.Paragraph;
    [AeCssVariable] public string AeOverlineFontWeight { get; set; } = AeFontWeights.Overline;

    
    [AeCssVariable] public string AeH1LineHeight { get; set; } = AeLineHeights.H1;
    [AeCssVariable] public string AeH2LineHeight { get; set; } = AeLineHeights.H2;
    [AeCssVariable] public string AeH3LineHeight { get; set; } = AeLineHeights.H3;
    [AeCssVariable] public string AeH4LineHeight { get; set; } = AeLineHeights.H4;
    [AeCssVariable] public string AeH5LineHeight { get; set; } = AeLineHeights.H5;
    [AeCssVariable] public string AeH6LineHeight { get; set; } = AeLineHeights.H6;
    
    [AeCssVariable] public string AeSubtitleLineHeight { get; set; } = AeLineHeights.Subtitle;
    [AeCssVariable] public string AeTextLineHeight { get; set; } = AeLineHeights.Text;
    [AeCssVariable] public string AeParagraphLineHeight { get; set; } = AeLineHeights.Paragraph;
    [AeCssVariable] public string AeOverlineLineHeight { get; set; } = AeLineHeights.Overline;
}

public static class AeFontSizes
{
    public static readonly string H1 = "6rem";
    public static readonly string H2 = "3.75rem";
    public static readonly string H3 = "3rem";
    public static readonly string H4 = "2.125rem";
    public static readonly string H5 = "1.5rem";
    public static readonly string H6 = "1.25rem";

    public static readonly string Subtitle = "0.875rem";
    public static readonly string Text = "1rem";
    public static readonly string Paragraph = "1rem";
    public static readonly string Overline = "0.75rem";
}

public static class AeLineHeights
{
    public static readonly string H1 = "1.167";
    public static readonly string H2 = "1.2";
    public static readonly string H3 = "1.167";
    public static readonly string H4 = "1.235";
    public static readonly string H5 = "1.334";
    public static readonly string H6 = "1.6";
    
    public static readonly string Subtitle = "1.57";
    public static readonly string Text = "1.5";
    public static readonly string Paragraph = "1.5";
    public static readonly string Overline = "2.66";
}

public static class AeFontWeights
{
    public static readonly string H1 = "300";
    public static readonly string H2 = "300";
    public static readonly string H3 = "400";
    public static readonly string H4 = "400";
    public static readonly string H5 = "400";
    public static readonly string H6 = "500";
    
    public static readonly string Subtitle = "500";
    public static readonly string Text = "400";
    public static readonly string Paragraph = "400";
    public static readonly string Overline = "400";
}