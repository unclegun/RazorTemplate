using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a simple progress bar.
/// </summary>
[HtmlTargetElement("ui-progress")]
public sealed class ProgressTagHelper : TagHelper
{
    /// <summary>
    /// Gets or sets the progress value.
    /// </summary>
    [HtmlAttributeName("value")]
    public int Value { get; set; }

    /// <summary>
    /// Gets or sets the maximum value.
    /// </summary>
    [HtmlAttributeName("max")]
    public int Max { get; set; } = 100;

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "progress");
        output.Content.AppendHtml($"<div class=\"progress__bar\" style=\"width:{Math.Clamp(Value, 0, Max) / (double)Math.Max(Max, 1) * 100:F0}%\" role=\"progressbar\" aria-valuenow=\"{Value}\" aria-valuemin=\"0\" aria-valuemax=\"{Max}\"></div>");
    }
}
