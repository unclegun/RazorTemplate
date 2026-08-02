using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a breadcrumb navigation.
/// </summary>
[HtmlTargetElement("ui-breadcrumb")]
public sealed class BreadcrumbTagHelper : TagHelper
{
    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "nav";
        output.Attributes.SetAttribute("class", "breadcrumb");
        output.Attributes.SetAttribute("aria-label", "Breadcrumb");
        output.Content.AppendHtml("<ol class=\"breadcrumb__list\"></ol>");
    }
}
