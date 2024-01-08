using Docsy.Endpoints.Slices.Collections;
using Docsy.Endpoints.Slices.Collections.Groups;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Groups.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Schemas;
using Docsy.Endpoints.Slices.Schemas.Models;
using Docsy.Endpoints.Slices.Schemas.Persistence.Entities;
using StackExchange.Redis;

namespace Docsy.Endpoints.Slices.Common.Persistence;

public sealed class DataListerFactory : IDataListerFactory
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public DataListerFactory(
        IMongoCollectionFactory mongoCollectionFactory,
        IConnectionMultiplexer connectionMultiplexer)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
        _connectionMultiplexer = connectionMultiplexer;
    }

    public IDataLister<TEntity, TParentKey> GetLister<TEntity, TParentKey>()
        where TEntity : class
        where TParentKey : struct
    {
        var lister = typeof(TEntity).Name switch
        {
            nameof(CollectionEntity) => new CollectionLister(_mongoCollectionFactory) as IDataLister<TEntity, TParentKey>,
            nameof(EndpointEntity) => new EndpointLister(_mongoCollectionFactory) as IDataLister<TEntity, TParentKey>,
            nameof(GroupEntity) => new GroupLister(_mongoCollectionFactory) as IDataLister<TEntity, TParentKey>,
            nameof(SchemaEntity) => new SchemaLister(_mongoCollectionFactory) as IDataLister<TEntity, TParentKey>,
            _ => throw new UnknownEntityException(typeof(TEntity).Name),
        };
        if (lister is null)
        {
            throw new NotImplementedDataListerException(
                typeof(TEntity),
                typeof(TParentKey));
        }

        return lister;
    }

    public IDataLister<TEntity, TParentKey> GetStageLister<TEntity, TParentKey>() where TEntity : class where TParentKey : struct
    {
        var lister = typeof(TEntity).Name switch
        {
            nameof(Endpoint) => new EndpointStageLister(_connectionMultiplexer) as IDataLister<TEntity, TParentKey>,
            nameof(Schema) => new SchemaStageLister(_connectionMultiplexer) as IDataLister<TEntity, TParentKey>,
            _ => throw new UnknownEntityException(typeof(TEntity).Name),
        };
        if (lister is null)
        {
            throw new NotImplementedDataListerException(
                typeof(TEntity),
                typeof(TParentKey));
        }

        return lister;
    }
}
