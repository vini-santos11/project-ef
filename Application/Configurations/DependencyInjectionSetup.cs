using Cross.Cutting.IoC;

namespace Application.Configurations;

public static class DependencyInjectionSetup
{

    public static void AddDependencyInjection(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        DependencyInjection.RegisterServicesAndRepositories(services);
    }
}