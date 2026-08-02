using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Enums;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a semantic card container.
/// </summary>
[HtmlTargetElement("ui-card")]
public sealed class CardTagHelper : TagHelper
{
    private readonly IIdGenerator _idGenerator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CardTagHelper"/> class.
    /// </summary>
    /// <param name="idGenerator">Generator for tracking IDs.</param>
    public CardTagHelper(IIdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
    }

    /// <summary>
    /// Gets or sets the optional title.
    /// </summary>
    [HtmlAttributeName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the variant.
    /// </summary>
    [HtmlAttributeName("variant")]
    public CardVariant Variant { get; set; } = CardVariant.Default;

    /// <summary>
    /// Gets or sets the element tag name.
    /// </summary>
    [HtmlAttributeName("element")]
    public string Element { get; set; } = "section";

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        TagHelperValidation.EnsureAllowedElement(Element, "section", "article", "div");
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = Element;

        var titleId = _idGenerator.Create("card-title");
        output.Attributes.SetAttribute("class", new CssClassBuilder().Add("card").Add("card--" + Variant.ToString().ToLowerInvariant(), Variant != CardVariant.Default).ToString());
        if (!string.IsNullOrWhiteSpace(Title))
        {
            output.Attributes.SetAttribute("aria-labelledby", titleId);
        }

        output.Content.AppendHtml($"<div class=\"card__header\"><h3 class=\"card__title\" id=\"{titleId}\">{Title}</h3></div>");
    }
}
