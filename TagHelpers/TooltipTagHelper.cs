using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a tooltip association for an element.
/// </summary>
[HtmlTargetElement("ui-tooltip")]
public sealed class TooltipTagHelper : TagHelper
{
    /// <summary>
    /// Gets or sets the tooltip text.
    /// </summary>
    [HtmlAttributeName("text")]
    public string? Text { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "span";
        output.Attributes.SetAttribute("class", new CssClassBuilder().Add("tooltip").ToString());
        output.Content.SetHtmlContent(Text ?? string.Empty);
    }
}
