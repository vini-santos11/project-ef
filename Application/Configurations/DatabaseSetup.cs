using Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace Application.Configurations;

public static class DatabaseSetup
{

    public static void AddDatabaseSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
    }
}