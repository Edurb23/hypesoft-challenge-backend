using Hypesoft.Domain.Repositories;
using Hypesoft.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Hypesoft.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoConnection = configuration.GetConnectionString("MongoDb");
        services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoConnection));

        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
