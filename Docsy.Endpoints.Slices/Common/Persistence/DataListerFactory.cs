using Docsy.Endpoints.Slices.Collections;
using Docsy.Endpoints.Slices.Collections.Groups;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Groups.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Schemas;
using Docsy.Endpoints.Slices.Schemas.Persistence.Entities;

namespace Docsy.Endpoints.Slices.Common.Persistence;

public sealed class DataListerFactory : IDataListerFactory
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public DataListerFactory(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
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
}
