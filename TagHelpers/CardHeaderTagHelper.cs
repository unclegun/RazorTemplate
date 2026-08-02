using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Wraps a card header section.
/// </summary>
[HtmlTargetElement("ui-card-header")]
public sealed class CardHeaderTagHelper : TagHelper
{
    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "card__header");
    }
}
