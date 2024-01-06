namespace Docsy.Endpoints.Slices.Common.Persistence;

public interface IDataReader<TEntity, in TKey>
    where TEntity : class
    where TKey : struct
{
    Task<TEntity?> GetEntityOrDefault(TKey key);
}
