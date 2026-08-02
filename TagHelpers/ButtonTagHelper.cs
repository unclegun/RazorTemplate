using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Enums;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a semantic button or link styled as a button.
/// </summary>
[HtmlTargetElement("ui-button")]
public sealed class ButtonTagHelper : TagHelper
{
    private readonly IIdGenerator _idGenerator;

    /// <summary>
    /// Initializes a new instance of the <see cref="ButtonTagHelper"/> class.
    /// </summary>
    /// <param name="idGenerator">Generator for safe IDs.</param>
    public ButtonTagHelper(IIdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
    }

    /// <summary>
    /// Gets or sets the visual variant.
    /// </summary>
    [HtmlAttributeName("variant")]
    public ButtonVariant Variant { get; set; } = ButtonVariant.Primary;

    /// <summary>
    /// Gets or sets the size.
    /// </summary>
    [HtmlAttributeName("size")]
    public ButtonSize Size { get; set; } = ButtonSize.Medium;

    /// <summary>
    /// Gets or sets the optional icon name.
    /// </summary>
    [HtmlAttributeName("icon")]
    public string? Icon { get; set; }

    /// <summary>
    /// Gets or sets the navigation page target.
    /// </summary>
    [HtmlAttributeName("asp-page")]
    public string? Page { get; set; }

    /// <summary>
    /// Gets or sets the href.
    /// </summary>
    [HtmlAttributeName("href")]
    public string? Href { get; set; }

    /// <summary>
    /// Gets or sets whether the control should be disabled.
    /// </summary>
    [HtmlAttributeName("disabled")]
    public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets whether the control is in a loading state.
    /// </summary>
    [HtmlAttributeName("loading")]
    public bool Loading { get; set; }

    /// <summary>
    /// Gets or sets the button type.
    /// </summary>
    [HtmlAttributeName("type")]
    public string? Type { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;

        var classes = new CssClassBuilder()
            .Add("button")
            .Add("button--" + Variant.ToString().ToLowerInvariant(), Variant != ButtonVariant.Default)
            .Add("button--" + Size.ToString().ToLowerInvariant(), Size != ButtonSize.Medium)
            .Add("button--icon", !string.IsNullOrWhiteSpace(Icon) && string.IsNullOrWhiteSpace(output.GetChildContentAsync().Result.GetContent()))
            .Add("is-loading", Loading)
            .Add("is-disabled", Disabled);

        var isLink = !string.IsNullOrWhiteSpace(Page) || !string.IsNullOrWhiteSpace(Href);
        output.TagName = isLink ? "a" : "button";
        output.Attributes.SetAttribute("class", classes.ToString());

        if (isLink)
        {
            output.Attributes.SetAttribute("href", string.IsNullOrWhiteSpace(Href) ? Page ?? "#" : Href);
            output.Attributes.RemoveAll("type");
        }
        else
        {
            output.Attributes.SetAttribute("type", string.IsNullOrWhiteSpace(Type) ? "button" : Type);
        }

        if (Disabled)
        {
            output.Attributes.SetAttribute("aria-disabled", "true");
            if (!isLink)
            {
                output.Attributes.SetAttribute("disabled", "disabled");
            }
        }

        if (Loading)
        {
            output.Content.AppendHtml("<span class=\"button__icon\" aria-hidden=\"true\">↻</span>");
        }
        else if (!string.IsNullOrWhiteSpace(Icon))
        {
            output.Content.AppendHtml($"<span class=\"button__icon\" aria-hidden=\"true\">{Icon}</span>");
        }

        if (output.Content.IsModified)
        {
            output.Content.AppendHtml(" ");
        }

        output.Content.AppendHtml("<span class=\"button__label\"></span>");

        var content = output.GetChildContentAsync().Result.GetContent();
        if (string.IsNullOrWhiteSpace(content))
        {
            output.Attributes.SetAttribute("aria-label", string.IsNullOrWhiteSpace(Icon) ? "Button" : Icon);
            output.Attributes.RemoveAll("class");
            output.Attributes.SetAttribute("class", new CssClassBuilder().Add("button").Add("button--icon").ToString());
        }
        else
        {
            var existingAriaLabel = output.Attributes.FirstOrDefault(attribute => string.Equals(attribute.Name, "aria-label", StringComparison.OrdinalIgnoreCase));
            if (existingAriaLabel is not null)
            {
                output.Attributes.SetAttribute("aria-label", existingAriaLabel.Value?.ToString());
            }
        }

        output.Attributes.SetAttribute("data-ui-id", _idGenerator.Create("button"));
    }
}
