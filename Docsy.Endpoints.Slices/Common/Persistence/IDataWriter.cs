namespace Docsy.Endpoints.Slices.Common.Persistence;

public interface IDataWriter<TEntity>
    where TEntity : class
{
    Task<TEntity> WriteEntity(TEntity entity);
}
