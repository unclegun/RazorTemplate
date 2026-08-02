using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders a single tab panel entry.
/// </summary>
[HtmlTargetElement("ui-tab")]
public sealed class TabTagHelper : TagHelper
{
    private readonly IIdGenerator _idGenerator;

    /// <summary>
    /// Initializes a new instance of the <see cref="TabTagHelper"/> class.
    /// </summary>
    /// <param name="idGenerator">Generator for safe IDs.</param>
    public TabTagHelper(IIdGenerator idGenerator)
    {
        _idGenerator = idGenerator;
    }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    [HtmlAttributeName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets whether the tab is active on load.
    /// </summary>
    [HtmlAttributeName("active")]
    public bool Active { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "tab-panel");

        var tabId = _idGenerator.Create("tab");
        var panelId = _idGenerator.Create("panel");
        var label = Title ?? "Tab";
        output.Content.SetHtmlContent($"<button id=\"{tabId}\" role=\"tab\" aria-selected=\"{(Active ? "true" : "false")}\" aria-controls=\"{panelId}\" tabindex=\"{(Active ? 0 : -1)}\">{label}</button><div id=\"{panelId}\" role=\"tabpanel\"{(Active ? string.Empty : " hidden")}>{output.GetChildContentAsync().Result.GetContent()}</div>");
    }
}
