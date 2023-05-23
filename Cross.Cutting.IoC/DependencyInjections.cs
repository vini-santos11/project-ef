using Infra.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
namespace Cross.Cutting.IoC;

public static class DependencyInjection
{
    public static void RegisterServicesAndRepositories(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();
        RegisterServices(services);
        RegisterRepositories(services);
    }

    public static void RegisterServices(this IServiceCollection services) { }
    public static void RegisterRepositories(this IServiceCollection services) { }
}