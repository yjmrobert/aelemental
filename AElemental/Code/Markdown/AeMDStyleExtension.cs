﻿using Markdig;
using Markdig.Extensions.Figures;
using Markdig.Extensions.Tables;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace AElemental.Code.Markdown;

public class AeMDStyleExtension : IMarkdownExtension
{
    public void Setup(MarkdownPipelineBuilder pipeline)
    {
        // Make sure we don't have a delegate twice
        pipeline.DocumentProcessed -= PipelineOnDocumentProcessed;
        pipeline.DocumentProcessed += PipelineOnDocumentProcessed;
    }

    public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
    {
    }

    private static void PipelineOnDocumentProcessed(MarkdownDocument document)
    {
        foreach (var node in document.Descendants())
            if (node is Block)
            {
                if (node is Table)
                    node.GetAttributes().AddClass("table");
                else if (node is QuoteBlock)
                    node.GetAttributes().AddClass("blockquote");
                else if (node is Figure)
                    node.GetAttributes().AddClass("figure");
                else if (node is FigureCaption)
                    node.GetAttributes().AddClass("figure-caption");
                else if (node is HeadingBlock headingBlock)
                    headingBlock.GetAttributes().AddClass($"ae typography h{headingBlock.Level}");
                else if (node is ParagraphBlock)
                    node.GetAttributes().AddClass("ae typography");
                else if (node is ListBlock listBlock) node.GetAttributes().AddClass("ae typography");
            }
            else if (node is Inline)
            {
                if (node is LinkInline link && link.IsImage) link.GetAttributes().AddClass("img-fluid");
            }
    }
}