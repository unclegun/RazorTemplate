using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Enums;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders an accessible alert container.
/// </summary>
[HtmlTargetElement("ui-alert")]
public sealed class AlertTagHelper : TagHelper
{
    /// <summary>
    /// Gets or sets the alert variant.
    /// </summary>
    [HtmlAttributeName("variant")]
    public AlertVariant Variant { get; set; } = AlertVariant.Info;

    /// <summary>
    /// Gets or sets an optional title.
    /// </summary>
    [HtmlAttributeName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets whether the alert is dismissible.
    /// </summary>
    [HtmlAttributeName("dismissible")]
    public bool Dismissible { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "section";

        var classes = new CssClassBuilder()
            .Add("alert")
            .Add("alert--" + Variant.ToString().ToLowerInvariant());

        output.Attributes.SetAttribute("class", classes.ToString());
        output.Attributes.SetAttribute("data-ui-alert", "true");

        var content = output.GetChildContentAsync().Result.GetContent();
        var body = string.IsNullOrWhiteSpace(content) ? string.Empty : content;
        output.Content.Clear();

        output.Content.AppendHtml("<div class=\"alert__body\">");
        if (!string.IsNullOrWhiteSpace(Title))
        {
            output.Content.AppendHtml($"<h3 class=\"alert__title\">{Title}</h3>");
        }
        output.Content.AppendHtml(body);
        output.Content.AppendHtml("</div>");

        if (Dismissible)
        {
            output.Content.AppendHtml("<button type=\"button\" class=\"button button--secondary button--sm\" data-dismiss-alert aria-label=\"Dismiss alert\">×</button>");
        }
    }
}
