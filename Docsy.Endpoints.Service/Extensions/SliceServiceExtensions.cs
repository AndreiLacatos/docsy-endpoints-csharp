using Docsy.Endpoints.Slices.Collections;
using Docsy.Endpoints.Slices.Collections.Groups;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints;
using Docsy.Endpoints.Slices.Common.Persistence;
using Docsy.Endpoints.Slices.Schemas;
using StackExchange.Redis;

namespace Docsy.Endpoints.Extensions;

public static class SliceServiceExtensions
{
    public static void AddSliceServices(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection
            .AddOptions<MongoConnectionOptions>()
            .BindConfiguration("MongoDbConfig");
        serviceCollection.AddSingleton<IConnectionMultiplexer>(_ =>
        {
            var address = configuration.GetValue<string>("RedisConnection:Address");
            return ConnectionMultiplexer.Connect(address!);
        });
        serviceCollection.AddScoped<IMongoCollectionFactory, MongoCollectionFactory>();
        serviceCollection.AddScoped<IDataReaderFactory, DataReaderFactory>();
        serviceCollection.AddScoped<IDataListerFactory, DataListerFactory>();
        serviceCollection.AddScoped<IDataWriterFactory, DataWriterFactory>();
        serviceCollection.AddScoped<ICollectionService, CollectionService>();
        serviceCollection.AddScoped<IGroupService, GroupService>();
        serviceCollection.AddScoped<IEndpointService, EndpointService>();
        serviceCollection.AddScoped<ISchemaService, SchemaService>();
    }
}
