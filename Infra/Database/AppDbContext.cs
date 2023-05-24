using System.Reflection;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
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
            optionsBuilder.UseNpgsql(connectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }
}