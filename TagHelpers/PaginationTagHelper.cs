using Microsoft.AspNetCore.Razor.TagHelpers;
using RazorTemplate.UI.Infrastructure;
using RazorTemplate.UI.Models;

namespace RazorTemplate.TagHelpers;

/// <summary>
/// Renders accessible pagination.
/// </summary>
[HtmlTargetElement("ui-pagination")]
public sealed class PaginationTagHelper : TagHelper
{
    /// <summary>
    /// Gets or sets the pagination model.
    /// </summary>
    [HtmlAttributeName("model")]
    public PaginationModel? Model { get; set; }

    /// <summary>
    /// Gets or sets the page base path.
    /// </summary>
    [HtmlAttributeName("asp-page")]
    public string? Page { get; set; }

    /// <inheritdoc />
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagMode = TagMode.StartTagAndEndTag;
        output.TagName = "nav";
        output.Attributes.SetAttribute("class", new CssClassBuilder().Add("pagination").ToString());
        output.Attributes.SetAttribute("aria-label", "Pagination");

        var model = Model ?? new PaginationModel { CurrentPage = 1, TotalPages = 1, PageSize = 10, TotalItems = 10 };
        var current = Math.Clamp(model.CurrentPage, 1, Math.Max(model.TotalPages, 1));
        var pageParameter = model.PageParameterName ?? "page";
        var content = $"<a class=\"pagination__link\" href=\"?{pageParameter}={Math.Max(1, current - 1)}\">Previous</a>";
        content += $"<span class=\"pagination__current\">Page {current} of {Math.Max(model.TotalPages, 1)}</span>";
        content += $"<a class=\"pagination__link\" href=\"?{pageParameter}={Math.Min(model.TotalPages, current + 1)}\">Next</a>";
        output.Content.SetHtmlContent(content);
    }
}
