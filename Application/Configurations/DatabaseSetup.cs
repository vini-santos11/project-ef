using Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace Application.Configurations;

public static class DatabaseSetup
{

    public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        string connectionString = configuration.GetConnectionString(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
        services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}