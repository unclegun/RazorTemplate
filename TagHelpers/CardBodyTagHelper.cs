using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Wraps card body content.
/// </summary>
[HtmlTargetElement("ui-card-body")]
public sealed class CardBodyTagHelper : TagHelper
{
    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "card__body");
    }
}
