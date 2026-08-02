using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a native dialog container.
/// </summary>
[HtmlTargetElement("ui-dialog")]
public sealed class DialogTagHelper : TagHelper
{
    /// <summary>
    /// Gets or sets the dialog identifier.
    /// </summary>
    [HtmlAttributeName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the dialog title.
    /// </summary>
    [HtmlAttributeName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the optional size.
    /// </summary>
    [HtmlAttributeName("size")]
    public string? Size { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "dialog";
        output.Attributes.SetAttribute("class", new CssClassBuilder().Add("dialog").Add("dialog--" + (string.IsNullOrWhiteSpace(Size) ? "md" : Size.ToLowerInvariant())).ToString());
        output.Attributes.SetAttribute("data-ui-dialog", "true");
        if (!string.IsNullOrWhiteSpace(Id))
        {
            output.Attributes.SetAttribute("id", Id);
        }

        output.Content.AppendHtml($"<div class=\"dialog__header\"><h2 class=\"dialog__title\">{Title}</h2></div>");
    }
}
