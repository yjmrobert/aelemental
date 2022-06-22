﻿using System;
using System.IO;
using AElemental.Code.Markdown;
using Markdig;
using Markdig.Renderers;
using Xunit;

namespace AElemental.Tests;

public class MarkdownTests
{
    private readonly MarkdownPipeline _pipeline;

    private readonly Func<string, string> rewrite_link = s => $"https://link?{s}";

    public MarkdownTests()
    {
        var builder = new MarkdownPipelineBuilder().UseAdvancedExtensions();
        builder.Extensions.AddIfNotAlready<AeMDStyleExtension>();
        //if (!builder.Extensions.Contains<AeMDLinkExtension>())
        //{
        //    builder.Extensions.Add(new AeMDLinkExtension(new[] {"abc" }));
        //}            
        _pipeline = builder.Build();

        var pipeline = new MarkdownPipelineBuilder().Build();
    }

    [Fact]
    public void GivenMDLink_RenderWithLinkRewrite()
    {
        var writer = new StringWriter();
        var renderer = new HtmlRenderer(writer);
        renderer.LinkRewriter = rewrite_link;
        _pipeline.Setup(renderer);
        var testMD = @"
#header
[page](/link/page)
";
        var doc = Markdown.Parse(testMD, _pipeline); // ToHtml(testMD, _pipeline);
        renderer.Render(doc);
        writer.Flush();
        var result = writer.ToString();
        Assert.Contains("https://link?", result);
    }

    [Fact]
    public void GivenMDHeader_RenderWithClass()
    {
        var writer = new StringWriter();
        var renderer = new HtmlRenderer(writer);
        renderer.LinkRewriter = rewrite_link;
        _pipeline.Setup(renderer);
        var testMD = @"
# Title1

## Title2

- element 1
- element 2
- element 3

";
        var doc = Markdown.Parse(testMD, _pipeline); // ToHtml(testMD, _pipeline);
        renderer.Render(doc);
        writer.Flush();
        var result = writer.ToString();
        Assert.Contains("class=\"ae typography h2\"", result);
        Assert.Contains("class=\"ae typography h1\"", result);
    }
}