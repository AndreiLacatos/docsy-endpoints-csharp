using Docsy.Endpoints.Slices.Collections;
using Docsy.Endpoints.Slices.Collections.Groups;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Collections.Models;

namespace Docsy.Endpoints.Slices.Common.Persistence;

public sealed class DataWriterFactory : IDataWriterFactory
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public DataWriterFactory(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
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
}
