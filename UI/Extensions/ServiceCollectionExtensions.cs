using Microsoft.Extensions.DependencyInjection;
using RazorTemplate.UI.Infrastructure;

namespace RazorTemplate.UI.Extensions;

/// <summary>
/// Service registration for UI helpers.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds template UI services.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddTemplateUi(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IIdGenerator, RequestIdGenerator>();
        return services;
    }
}