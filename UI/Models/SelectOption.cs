namespace RazorTemplate.UI.Models;

/// <summary>
/// Represents a select option item.
/// </summary>
public sealed class SelectOption
{
    /// <summary>
    /// Gets or sets option value.
    /// </summary>
    public string Value { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets display text.
    /// </summary>
    public string Text { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets whether the option is selected.
    /// </summary>
    public bool Selected { get; init; }
}