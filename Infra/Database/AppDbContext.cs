using System.Reflection;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Database;

public abstract class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    protected AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entityTypes = Assembly.GetExecutingAssembly()
                                  .GetTypes()
                                    .Where(t => t.BaseType != null &&
                                                t.BaseType.IsGenericType &&
                                                t.BaseType.GetGenericTypeDefinition() == typeof(Entity)
                                            );

        foreach (var entityType in entityTypes)
        {
            var setMethod = typeof(ModelBuilder).GetMethod("Set", Type.EmptyTypes).MakeGenericMethod(entityType);

            setMethod.Invoke(modelBuilder, null);
        }

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        base.OnConfiguring(optionsBuilder);
    }
}