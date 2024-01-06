namespace Docsy.Endpoints.Slices.Common.Persistence;

public interface IDataListerFactory
{
    IDataLister<TEntity, TParentKey> GetLister<TEntity, TParentKey>()
        where TEntity : class
        where TParentKey : struct;
}
