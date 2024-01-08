namespace Docsy.Endpoints.Slices.Common.Persistence;

public interface IDataReaderFactory
{
    IDataReader<TEntity, TKey> GetReader<TEntity, TKey>()
        where TEntity : class
        where TKey : struct;
    IDataReader<TEntity, TKey> GetStageReader<TEntity, TKey>()
        where TEntity : class
        where TKey : struct;
}
