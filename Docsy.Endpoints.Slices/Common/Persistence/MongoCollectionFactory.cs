using System.Collections.ObjectModel;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Schemas.Models;
using Docsy.Endpoints.Slices.Schemas.Persistence.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Docsy.Endpoints.Slices.Common.Persistence;

public sealed class MongoCollectionFactory : IMongoCollectionFactory
{
    private readonly MongoConnectionOptions _options;

    private static readonly ReadOnlyDictionary<Type, string> CollectionMap =
        new Dictionary<Type, string>
        {
            { typeof(CollectionEntity), nameof(Collection).ToLower() },
            { typeof(EndpointEntity), nameof(Endpoint).ToLower() },
            { typeof(SchemaEntity), nameof(Schema).ToLower() },
        }.AsReadOnly();

    public MongoCollectionFactory(IOptions<MongoConnectionOptions> mongoOptions)
    {
        _options = mongoOptions.Value;
    }

    public IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : class
    {
        var client = new MongoClient(_options.ConnectionString);
        var db = client.GetDatabase(_options.DatabaseName);
        if (!CollectionMap.TryGetValue(typeof(TEntity), out var collectionName))
        {
            throw new UnknownEntityException(typeof(TEntity).Name);
        }

        return db.GetCollection<TEntity>(collectionName);
    }
}
