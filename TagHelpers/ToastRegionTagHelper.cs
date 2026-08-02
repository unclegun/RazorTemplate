using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a live region for toast notifications.
/// </summary>
[HtmlTargetElement("ui-toast-region")]
public sealed class ToastRegionTagHelper : TagHelper
{
    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "div";
        output.Attributes.SetAttribute("class", new CssClassBuilder().Add("toast-region").ToString());
        output.Attributes.SetAttribute("aria-live", "polite");
        output.Attributes.SetAttribute("data-toast-region", "true");
    }
}
