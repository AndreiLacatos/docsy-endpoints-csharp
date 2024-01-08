using Docsy.Endpoints.Slices.Collections;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using StackExchange.Redis;

namespace Docsy.Endpoints.Slices.Common.Persistence;

public sealed class DataReaderFactory : IDataReaderFactory
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public DataReaderFactory(
        IMongoCollectionFactory mongoCollectionFactory,
        IConnectionMultiplexer connectionMultiplexer)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
        _connectionMultiplexer = connectionMultiplexer;
    }

    public IDataReader<TEntity, TKey> GetReader<TEntity, TKey>()
        where TEntity : class
        where TKey : struct
    {
        var reader = typeof(TEntity).Name switch
        {
            nameof(CollectionEntity) => new CollectionReader(_mongoCollectionFactory),
            _ => throw new UnknownEntityException(typeof(TEntity).Name),
        };
        if (reader is not IDataReader<TEntity, TKey> dataReader)
        {
            throw new NotImplementedDataReaderException(
                typeof(TEntity),
                typeof(TKey));
        }

        return dataReader;
    }

    public IDataReader<TEntity, TKey> GetStageReader<TEntity, TKey>() where TEntity : class where TKey : struct
    {
        var reader = typeof(TEntity).Name switch
        {
            nameof(Collection) => new CollectionStageReader(_connectionMultiplexer),
            _ => throw new UnknownEntityException(typeof(TEntity).Name),
        };
        if (reader is not IDataReader<TEntity, TKey> dataReader)
        {
            throw new NotImplementedDataReaderException(
                typeof(TEntity),
                typeof(TKey));
        }

        return dataReader;
    }
}
