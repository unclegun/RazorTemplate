using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Wraps card footer content.
/// </summary>
[HtmlTargetElement("ui-card-footer")]
public sealed class CardFooterTagHelper : TagHelper
{
    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "card__footer");
    }
}
