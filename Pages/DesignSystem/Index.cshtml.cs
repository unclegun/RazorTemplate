using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTemplate.UI.Models;

namespace RazorTemplate.Pages.DesignSystem;

/// <summary>
/// Sample page for the design system showcase.
/// </summary>
public sealed class IndexModel : PageModel
{
    /// <summary>
    /// Gets or sets the sample study name.
    /// </summary>
    [BindProperty]
    public InputModel Input { get; set; } = new();

    /// <summary>
    /// Gets the sample pagination state.
    /// </summary>
    public PaginationModel Pagination { get; } = new()
    {
        CurrentPage = 2,
        TotalPages = 7,
        PageSize = 10,
        TotalItems = 64,
        PageParameterName = "page"
    };

    /// <summary>
    /// Input model for the example form.
    /// </summary>
    public sealed class InputModel
    {
        /// <summary>
        /// Gets or sets the study name.
        /// </summary>
        public string StudyName { get; set; } = "Phase III Oncology Trial";

        /// <summary>
        /// Gets or sets the research lead.
        /// </summary>
        public string ResearchLead { get; set; } = "Dr. L. Moreno";
    }
}
