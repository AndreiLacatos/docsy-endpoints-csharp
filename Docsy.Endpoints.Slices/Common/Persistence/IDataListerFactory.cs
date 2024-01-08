namespace Docsy.Endpoints.Slices.Common.Persistence;

public interface IDataListerFactory
{
    IDataLister<TEntity, TParentKey> GetLister<TEntity, TParentKey>()
        where TEntity : class
        where TParentKey : struct;
    IDataLister<TEntity, TParentKey> GetStageLister<TEntity, TParentKey>()
        where TEntity : class
        where TParentKey : struct;
}
