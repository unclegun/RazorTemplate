using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a field hint block.
/// </summary>
[HtmlTargetElement("ui-field-hint")]
public sealed class FieldHintTagHelper : TagHelper
{
    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "form-field__hint");
    }
}
