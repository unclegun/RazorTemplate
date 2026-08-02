using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders an individual breadcrumb item.
/// </summary>
[HtmlTargetElement("ui-breadcrumb-item")]
public sealed class BreadcrumbItemTagHelper : TagHelper
{
    /// <summary>
    /// Gets or sets the link href.
    /// </summary>
    [HtmlAttributeName("href")]
    public string? Href { get; set; }

    /// <summary>
    /// Gets or sets whether the item is current.
    /// </summary>
    [HtmlAttributeName("current")]
    public bool Current { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "li";
        output.Attributes.SetAttribute("class", new CssClassBuilder().Add("breadcrumb__item").Add("is-current", Current).ToString());

        var content = output.GetChildContentAsync().Result.GetContent();
        var inner = string.IsNullOrWhiteSpace(content) ? "Item" : content;
        var tag = Current ? "span" : "a";
        var href = Current ? string.Empty : $" href=\"{Href ?? "#"}\"";
        output.Content.SetHtmlContent($"<{tag}{href} class=\"breadcrumb__link\">{inner}</{tag}>");
    }
}
