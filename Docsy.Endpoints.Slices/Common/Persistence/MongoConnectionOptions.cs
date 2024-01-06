namespace Docsy.Endpoints.Slices.Common.Persistence;

public sealed class MongoConnectionOptions
{
    public required string ConnectionString { get; set; }
    public required string DatabaseName { get; set; }
}
