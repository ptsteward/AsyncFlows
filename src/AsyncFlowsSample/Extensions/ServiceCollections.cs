using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AsyncFlows.Modules.Extensions;

public static class ServiceCollections
{
    public static bool ContainsImplementation<TImplementation>(this IServiceCollection services)
        => services.ContainsImplementation(typeof(TImplementation));

    public static bool ContainsImplementation(this IServiceCollection services, Type implementationType)
        => services.Any(s => s.ImplementationType == implementationType);

    public static bool ContainsService<TService>(this IServiceCollection services)
        => services.ContainsService(typeof(TService));

    public static bool ContainsService(this IServiceCollection services, Type ServiceType)
        => services.Any(s => s.ServiceType == ServiceType);

    public static IServiceCollection SetSingleton(
        this IServiceCollection services,
        Type service)
    {
        services.TryAddSingleton(service);
        return services;
    }

    public static IServiceCollection SetSingleton(
        this IServiceCollection services,
        Type service,
        Type implementation)
    {
        services.TryAddSingleton(service, implementation);
        return services;
    }

    public static IServiceCollection SetSingleton(
        this IServiceCollection services,
        Type service,
        Func<IServiceProvider, object> factory)
    {
        services.TryAddSingleton(service, factory);
        return services;
    }

    public static IServiceCollection SetSingleton<TService>(
        this IServiceCollection services)
        where TService : class
    {
        services.TryAddSingleton<TService>();
        return services;
    }

    public static IServiceCollection SetSingleton<TImplementation>(
        this IServiceCollection services,
        Func<IServiceProvider, TImplementation> factory)
        where TImplementation : class
    {
        services.TryAddSingleton(factory);
        return services;
    }

    public static IServiceCollection SetSingleton<TService>(
        this IServiceCollection services,
        TService instance)
        where TService : class
    {
        services.TryAddSingleton(instance);
        return services;
    }

    public static IServiceCollection SetSingleton<TService, TImplementation>(
        this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        services.TryAddSingleton<TService, TImplementation>();
        return services;
    }
}
