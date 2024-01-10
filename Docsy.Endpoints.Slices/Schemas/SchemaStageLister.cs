using System.Text.Json;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Common.Persistence;
using Docsy.Endpoints.Slices.Schemas.Models;
using StackExchange.Redis;

namespace Docsy.Endpoints.Slices.Schemas;

internal sealed class SchemaStageLister : IDataLister<Schema, CollectionId>
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public SchemaStageLister(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<IEnumerable<Schema>> ListEntities(CollectionId key)
    {
        var database = _connectionMultiplexer.GetDatabase();
        var redisKey = $"{key.Value.ToString()}:schemas";
        var stagedValues = await database.StringGetAsync(redisKey);
        if (!string.IsNullOrWhiteSpace(stagedValues.ToString()))
        {
            var stage = JsonSerializer.Deserialize<IEnumerable<Schema>>(
                stagedValues.ToString(),
                options: StageJsonSerializerOptions.SharedOptions);
            if (stage is not null)
            {
                return stage;
            }
        }

        return Enumerable.Empty<Schema>();
    }
}
