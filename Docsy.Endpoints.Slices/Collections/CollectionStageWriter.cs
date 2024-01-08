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
        var stagedValues = await database.StringGetAsync(redisKey);
        if (!string.IsNullOrWhiteSpace(stagedValues.ToString()))
        {
            var stage = JsonSerializer.Deserialize<Collection>(
                stagedValues.ToString(),
                options: StageJsonSerializerOptions.SharedOptions);
            if (stage is not null)
            {
                CollectionMapper.Map(obj, stage);
                var serialized = JsonSerializer.Serialize(stage, StageJsonSerializerOptions.SharedOptions);
                await database.StringSetAsync(
                    redisKey,
                    serialized,
                    TimeSpan.FromDays(45));
            }
        }

        return obj;
    }
}
