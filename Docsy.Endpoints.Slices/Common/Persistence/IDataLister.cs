namespace Docsy.Endpoints.Slices.Common.Persistence;

public interface IDataLister<TEntity, in TParentKey>
    where TEntity : class
    where TParentKey : struct
{
    Task<IEnumerable<TEntity>> ListEntities(TParentKey key);
}
