using Docsy.Endpoints.Slices.Collections;
using Docsy.Endpoints.Slices.Collections.Groups;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Schemas;
using Docsy.Endpoints.Slices.Schemas.Models;
using StackExchange.Redis;

namespace Docsy.Endpoints.Slices.Common.Persistence;

public sealed class DataWriterFactory : IDataWriterFactory
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public DataWriterFactory(
        IMongoCollectionFactory mongoCollectionFactory,
        IConnectionMultiplexer connectionMultiplexer)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
        _connectionMultiplexer = connectionMultiplexer;
    }

    public IDataWriter<TEntity> GetWriter<TEntity>() where TEntity : class
    {
        var writer = typeof(TEntity).Name switch
        {
            nameof(Collection) => new CollectionWriter(_mongoCollectionFactory) as IDataWriter<TEntity>,
            nameof(Group) => new GroupWriter(_mongoCollectionFactory) as IDataWriter<TEntity>,
            _ => throw new UnknownEntityException(typeof(TEntity).Name),
        };
        if (writer is null)
        {
            throw new NotImplementedDataWriterException(typeof(TEntity));
        }

        return writer;
    }

    public IDataWriter<TEntity> GetStageWriter<TEntity>() where TEntity : class
    {
        var writer = typeof(TEntity).Name switch
        {
            nameof(Collection) => new CollectionStageWriter(_connectionMultiplexer) as IDataWriter<TEntity>,
            nameof(Endpoint) => new EndpointStageWriter(_connectionMultiplexer) as IDataWriter<TEntity>,
            nameof(Schema) => new SchemaStageWriter(_connectionMultiplexer) as IDataWriter<TEntity>,
            _ => throw new UnknownEntityException(typeof(TEntity).Name),
        };
        if (writer is null)
        {
            throw new NotImplementedDataWriterException(typeof(TEntity));
        }

        return writer;
    }
}
