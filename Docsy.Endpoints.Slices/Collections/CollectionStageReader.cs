using System.Text.Json;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Common.Persistence;
using StackExchange.Redis;

namespace Docsy.Endpoints.Slices.Collections;

internal sealed class CollectionStageReader : IDataReader<Collection, CollectionId>
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public CollectionStageReader(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<Collection?> GetEntityOrDefault(CollectionId key)
    {
        var database = _connectionMultiplexer.GetDatabase();
        var redisKey = key.Value.ToString();
        var stagedValues = await database.StringGetAsync(redisKey);
        if (!string.IsNullOrWhiteSpace(stagedValues.ToString()))
        {
            var stage = JsonSerializer.Deserialize<Collection>(
                stagedValues.ToString(),
                options: StageJsonSerializerOptions.SharedOptions);
            if (stage is not null)
            {
                return stage;
            }
        }

        return null;
    }
}
