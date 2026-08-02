using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Enums;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a form field with label, hint, and validation support.
/// </summary>
[HtmlTargetElement("ui-field")]
public sealed class FieldTagHelper : TagHelper
{
    private readonly IHtmlGenerator _htmlGenerator;

    /// <summary>
    /// Initializes a new instance of the <see cref="FieldTagHelper"/> class.
    /// </summary>
    /// <param name="htmlGenerator">HTML generator.</param>
    public FieldTagHelper(IHtmlGenerator htmlGenerator)
    {
        _htmlGenerator = htmlGenerator;
    }

    /// <summary>
    /// Gets or sets the model expression.
    /// </summary>
    [HtmlAttributeName("asp-for")]
    public ModelExpression? For { get; set; }

    /// <summary>
    /// Gets or sets the label text.
    /// </summary>
    [HtmlAttributeName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the hint text.
    /// </summary>
    [HtmlAttributeName("hint")]
    public string? Hint { get; set; }

    /// <summary>
    /// Gets or sets the autocomplete value.
    /// </summary>
    [HtmlAttributeName("autocomplete")]
    public string? Autocomplete { get; set; }

    /// <summary>
    /// Gets or sets the field type.
    /// </summary>
    [HtmlAttributeName("type")]
    public string? Type { get; set; } = "text";

    /// <summary>
    /// Gets or sets the layout.
    /// </summary>
    [HtmlAttributeName("layout")]
    public FieldLayout Layout { get; set; } = FieldLayout.Stacked;

    /// <summary>
    /// Gets or sets whether the field is required.
    /// </summary>
    [HtmlAttributeName("required")]
    public bool Required { get; set; }

    /// <summary>
    /// Gets or sets whether the field is readonly.
    /// </summary>
    [HtmlAttributeName("readonly")]
    public bool ReadOnly { get; set; }

    /// <summary>
    /// Gets or sets whether the field is disabled.
    /// </summary>
    [HtmlAttributeName("disabled")]
    public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets the prefix.
    /// </summary>
    [HtmlAttributeName("prefix")]
    public string? Prefix { get; set; }

    /// <summary>
    /// Gets or sets the suffix.
    /// </summary>
    [HtmlAttributeName("suffix")]
    public string? Suffix { get; set; }

    /// <summary>
    /// Gets or sets the input element name.
    /// </summary>
    [HtmlAttributeName("element")]
    public string Element { get; set; } = "input";

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        TagHelperValidation.EnsureAllowedElement(Element, "input", "textarea", "select");
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "div";
        output.Attributes.SetAttribute("class", new CssClassBuilder().Add("form-field").Add("form-field--horizontal", Layout == FieldLayout.Horizontal).ToString());

        var fieldId = For?.Name?.Replace('.', '_') ?? "field";
        var hintId = fieldId + "-hint";
        var errorId = fieldId + "-error";
        var labelText = Label ?? For?.Metadata.DisplayName ?? For?.Name ?? fieldId;
        var isRequired = Required || For?.Metadata.IsRequired == true;

        var label = new TagBuilder("label");
        label.AddCssClass("form-field__label");
        label.Attributes.Add("for", fieldId);
        var text = new TagBuilder("span");
        text.InnerHtml.Append(labelText);
        label.InnerHtml.AppendHtml(text);
        if (isRequired)
        {
            var required = new TagBuilder("span");
            required.AddCssClass("form-field__required");
            required.Attributes.Add("aria-hidden", "true");
            required.InnerHtml.Append("*");
            label.InnerHtml.AppendHtml(required);
        }

        var controlBuilder = new TagBuilder(Element);
        controlBuilder.AddCssClass("form-field__control");
        controlBuilder.Attributes.Add("id", fieldId);
        controlBuilder.Attributes.Add("name", For?.Name ?? fieldId);
        controlBuilder.Attributes.Add("type", Type);
        if (!string.IsNullOrWhiteSpace(Autocomplete))
        {
            controlBuilder.Attributes.Add("autocomplete", Autocomplete);
        }
        if (ReadOnly)
        {
            controlBuilder.Attributes.Add("readonly", "readonly");
        }
        if (Disabled)
        {
            controlBuilder.Attributes.Add("disabled", "disabled");
        }
        if (isRequired)
        {
            controlBuilder.Attributes.Add("required", "required");
        }
        if (!string.IsNullOrWhiteSpace(Hint))
        {
            controlBuilder.Attributes.Add("aria-describedby", hintId);
        }

        var validationMessage = new TagBuilder("span");
        validationMessage.AddCssClass("form-field__error");
        validationMessage.Attributes.Add("id", errorId);
        validationMessage.Attributes.Add("data-valmsg-for", For?.Name ?? fieldId);

        var writer = new StringWriter();
        label.WriteTo(writer, NullHtmlEncoder.Default);
        controlBuilder.WriteTo(writer, NullHtmlEncoder.Default);
        if (!string.IsNullOrWhiteSpace(Hint))
        {
            var hint = new TagBuilder("div");
            hint.AddCssClass("form-field__hint");
            hint.Attributes.Add("id", hintId);
            hint.InnerHtml.Append(Hint);
            hint.WriteTo(writer, NullHtmlEncoder.Default);
        }
        validationMessage.WriteTo(writer, NullHtmlEncoder.Default);

        output.Content.SetHtmlContent(writer.ToString());
    }
}
