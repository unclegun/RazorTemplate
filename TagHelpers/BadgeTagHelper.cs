using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Enums;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a badge.
/// </summary>
[HtmlTargetElement("ui-badge")]
public sealed class BadgeTagHelper : TagHelper
{
    /// <summary>
    /// Gets or sets the visual variant.
    /// </summary>
    [HtmlAttributeName("variant")]
    public BadgeVariant Variant { get; set; } = BadgeVariant.Neutral;

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "span";
        output.Attributes.SetAttribute("class", new CssClassBuilder().Add("badge").Add("badge--" + Variant.ToString().ToLowerInvariant()).ToString());
    }
}
