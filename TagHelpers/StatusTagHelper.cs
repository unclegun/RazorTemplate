using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Enums;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a status pill with semantic styling.
/// </summary>
[HtmlTargetElement("ui-status")]
public sealed class StatusTagHelper : TagHelper
{
    /// <summary>
    /// Gets or sets the visual variant.
    /// </summary>
    [HtmlAttributeName("variant")]
    public StatusVariant Variant { get; set; } = StatusVariant.Neutral;

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "span";
        output.Attributes.SetAttribute("class", new CssClassBuilder().Add("status").Add("status--" + Variant.ToString().ToLowerInvariant()).ToString());
    }
}
