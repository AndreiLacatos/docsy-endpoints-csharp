using System.Text.Json;
using Docsy.Endpoints.Slices.Collections.Mapper;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Common.Persistence;
using StackExchange.Redis;

namespace Docsy.Endpoints.Slices.Collections;

internal sealed class CollectionStageWriter : IDataWriter<Collection>
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public CollectionStageWriter(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<Collection> WriteEntity(Collection obj)
    {
        var database = _connectionMultiplexer.GetDatabase();
        var redisKey = obj.CollectionId.Value.ToString();
        var serialized = JsonSerializer.Serialize(obj, StageJsonSerializerOptions.SharedOptions);
        await database.StringSetAsync(
            redisKey,
            serialized,
            TimeSpan.FromDays(45));
        return obj;
    }
}
