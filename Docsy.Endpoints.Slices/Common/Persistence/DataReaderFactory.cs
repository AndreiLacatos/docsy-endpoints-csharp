using Docsy.Endpoints.Slices.Collections;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;

namespace Docsy.Endpoints.Slices.Common.Persistence;

public sealed class DataReaderFactory : IDataReaderFactory
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public DataReaderFactory(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
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
}
