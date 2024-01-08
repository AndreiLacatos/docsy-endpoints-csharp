namespace Docsy.Endpoints.Slices.Common.Persistence;

public interface IDataWriterFactory
{
    IDataWriter<TEntity> GetWriter<TEntity>() where TEntity : class;
    IDataWriter<TEntity> GetStageWriter<TEntity>() where TEntity : class;
}
