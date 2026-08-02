using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a field error block.
/// </summary>
[HtmlTargetElement("ui-field-error")]
public sealed class FieldErrorTagHelper : TagHelper
{
    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "span";
        output.Attributes.SetAttribute("class", "form-field__error");
    }
}
