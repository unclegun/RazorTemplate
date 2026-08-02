namespace RazorTemplate.UI.Models;

/// <summary>
/// Describes pagination state.
/// </summary>
public sealed class PaginationModel
{
    /// <summary>
    /// Gets the current page.
    /// </summary>
    public int CurrentPage { get; init; }

    /// <summary>
    /// Gets the total page count.
    /// </summary>
    public int TotalPages { get; init; }

    /// <summary>
    /// Gets the selected page size.
    /// </summary>
    public int PageSize { get; init; }

    /// <summary>
    /// Gets the total item count.
    /// </summary>
    public int TotalItems { get; init; }

    /// <summary>
    /// Gets the page query parameter name.
    /// </summary>
    public string? PageParameterName { get; init; } = "page";
}