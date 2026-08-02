using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Wraps a tab group.
/// </summary>
[HtmlTargetElement("ui-tabs")]
public sealed class TabGroupTagHelper : TagHelper
{
    private readonly IIdGenerator _idGenerator;

    /// <summary>
    /// Initializes a new instance of the <see cref="TabGroupTagHelper"/> class.
    /// </summary>
    /// <param name="idGenerator">Generator for safe IDs.</param>
    public TabGroupTagHelper(IIdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
    }

    /// <summary>
    /// Gets or sets the label.
    /// </summary>
    [HtmlAttributeName("label")]
    public string? Label { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "section";
        output.Attributes.SetAttribute("class", new CssClassBuilder().Add("tabs").ToString());
        output.Attributes.SetAttribute("data-ui-tabs", _idGenerator.Create("tabs"));
        output.Content.AppendHtml($"<div role=\"tablist\" class=\"tabs__list\" aria-label=\"{Label ?? "Tabs"}\"></div>");
    }
}
