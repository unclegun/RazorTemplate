namespace RazorTemplate.UI.Infrastructure;

/// <summary>
/// Common validation helpers for UI Tag Helpers.
/// </summary>
public static class TagHelperValidation
{
    /// <summary>
    /// Ensures the provided element value is in the allowed list.
    /// </summary>
    public static void EnsureAllowedElement(string element, params string[] allowed)
    {
        if (!allowed.Contains(element, StringComparer.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException($"Element '{element}' is not valid. Allowed: {string.Join(", ", allowed)}.");
        }
    }

    /// <summary>
    /// Ensures a value is present.
    /// </summary>
    public static void EnsureRequired(string? value, string attributeName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"Attribute '{attributeName}' is required.");
        }
    }

    /// <summary>
    /// Ensures two attributes are not both specified.
    /// </summary>
    public static void EnsureMutuallyExclusive(bool firstExists, string firstName, bool secondExists, string secondName)
    {
        if (firstExists && secondExists)
        {
            throw new InvalidOperationException($"Attributes '{firstName}' and '{secondName}' cannot be used together.");
        }
    }

    /// <summary>
    /// Enforces link versus button behavior.
    /// </summary>
    public static void EnsureLinkOrButton(bool hasHref, string? type)
    {
        if (hasHref && !string.IsNullOrWhiteSpace(type) && !string.Equals(type, "button", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Type is not valid for link rendering.");
        }
    }
}