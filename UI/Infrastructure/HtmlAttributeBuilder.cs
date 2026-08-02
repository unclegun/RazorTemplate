using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RazorTemplate.UI.Infrastructure;

/// <summary>
/// Utility methods for copying and merging attributes.
/// </summary>
public static class HtmlAttributeBuilder
{
    /// <summary>
    /// Merges a class list into a TagHelper attribute dictionary.
    /// </summary>
    /// <param name="attributes">The target attributes.</param>
    /// <param name="classes">Class string to merge.</param>
    public static void MergeClass(TagHelperAttributeList attributes, string classes)
    {
        if (string.IsNullOrWhiteSpace(classes))
        {
            return;
        }

        if (attributes.TryGetAttribute("class", out var existing))
        {
            var merged = new CssClassBuilder().Add(existing.Value?.ToString()).Add(classes).ToString();
            attributes.SetAttribute("class", merged);
            return;
        }

        attributes.SetAttribute("class", classes);
    }
}