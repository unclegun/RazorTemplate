using Microsoft.AspNetCore.Http;

namespace RazorTemplate.UI.Infrastructure;

/// <summary>
/// Generates request-scoped IDs.
/// </summary>
public interface IIdGenerator
{
    /// <summary>
    /// Creates a unique ID for the current request.
    /// </summary>
    /// <param name="prefix">ID prefix.</param>
    /// <returns>A unique ID.</returns>
    string Create(string prefix);
}

/// <summary>
/// Request-scoped implementation of <see cref="IIdGenerator"/>.
/// </summary>
public sealed class RequestIdGenerator : IIdGenerator
{
    private const string CounterKey = "RazorTemplate.UI.IdGenerator.Counters";
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestIdGenerator"/> class.
    /// </summary>
    /// <param name="httpContextAccessor">Http context accessor.</param>
    public RequestIdGenerator(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    /// <inheritdoc />
    public string Create(string prefix)
    {
        var safePrefix = string.IsNullOrWhiteSpace(prefix) ? "ui" : prefix;
        var context = _httpContextAccessor.HttpContext;
        if (context is null)
        {
            return $"{safePrefix}-{Guid.NewGuid():N}";
        }

        if (!context.Items.TryGetValue(CounterKey, out var state) || state is not Dictionary<string, int> counters)
        {
            counters = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            context.Items[CounterKey] = counters;
        }

        counters.TryGetValue(safePrefix, out var value);
        value++;
        counters[safePrefix] = value;
        return $"{safePrefix}-{value}";
    }
}