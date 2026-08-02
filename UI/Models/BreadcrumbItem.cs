namespace RazorTemplate.UI.Models;

/// <summary>
/// Represents a single breadcrumb item.
/// </summary>
public sealed class BreadcrumbItem
{
    /// <summary>
    /// Gets or sets item text.
    /// </summary>
    public string Text { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets item URL.
    /// </summary>
    public string? Href { get; init; }

    /// <summary>
    /// Gets or sets whether this item is the current page.
    /// </summary>
    public bool Current { get; init; }
}