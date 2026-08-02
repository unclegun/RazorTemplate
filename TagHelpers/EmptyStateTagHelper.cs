using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders an empty-state container.
/// </summary>
[HtmlTargetElement("ui-empty-state")]
public sealed class EmptyStateTagHelper : TagHelper
{
    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    [HtmlAttributeName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    [HtmlAttributeName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the icon name.
    /// </summary>
    [HtmlAttributeName("icon")]
    public string? Icon { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "section";
        output.Attributes.SetAttribute("class", new CssClassBuilder().Add("empty-state").ToString());

        output.Content.AppendHtml($"<div class=\"empty-state__icon\" aria-hidden=\"true\">{Icon}</div>");
        output.Content.AppendHtml($"<h2 class=\"empty-state__title\">{Title}</h2>");
        output.Content.AppendHtml($"<p class=\"empty-state__message\">{Message}</p>");
    }
}
