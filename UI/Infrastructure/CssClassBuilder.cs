using System.Text;

namespace RazorTemplate.UI.Infrastructure;

/// <summary>
/// Builds deterministic CSS class strings.
/// </summary>
public sealed class CssClassBuilder
{
    private readonly HashSet<string> _classes = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Adds a class value.
    /// </summary>
    /// <param name="className">Class name or space-delimited names.</param>
    /// <returns>The builder.</returns>
    public CssClassBuilder Add(string? className)
    {
        if (string.IsNullOrWhiteSpace(className))
        {
            return this;
        }

        foreach (var item in className.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            _classes.Add(item);
        }

        return this;
    }

    /// <summary>
    /// Adds a class only when a condition is true.
    /// </summary>
    /// <param name="className">Class name.</param>
    /// <param name="condition">Condition to satisfy.</param>
    /// <returns>The builder.</returns>
    public CssClassBuilder Add(string? className, bool condition)
    {
        return condition ? Add(className) : this;
    }

    /// <summary>
    /// Adds multiple class names.
    /// </summary>
    /// <param name="classNames">Collection of class values.</param>
    /// <returns>The builder.</returns>
    public CssClassBuilder AddRange(IEnumerable<string?> classNames)
    {
        foreach (var className in classNames)
        {
            Add(className);
        }

        return this;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        var ordered = _classes.OrderBy(x => x, StringComparer.OrdinalIgnoreCase).ToList();
        var sb = new StringBuilder();
        for (var i = 0; i < ordered.Count; i++)
        {
            if (i > 0)
            {
                sb.Append(' ');
            }

            sb.Append(ordered[i]);
        }

        return sb.ToString();
    }
}