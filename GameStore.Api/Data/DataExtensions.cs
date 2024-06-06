using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace GameStore.Api.Data;

public static class DataExtensions
{
	public static async Task initializeDbAsync(this IServiceProvider  serviceProvider)
	{
        using var scope = serviceProvider.CreateScope() ;
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("GameStoreContext");
        services.AddSqlServer<GameStoreContext>(connString).
            AddScoped<IGamesRepository, EntityFrameworkGamesRepository>(); 
        return services;
    }
}
