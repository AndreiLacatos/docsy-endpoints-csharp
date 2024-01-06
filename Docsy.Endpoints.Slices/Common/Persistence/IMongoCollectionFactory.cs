using MongoDB.Driver;

namespace Docsy.Endpoints.Slices.Common.Persistence;

public interface IMongoCollectionFactory
{
    IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : class;
}
