using System.Text.Json;
using Docsy.Endpoints.Slices.Common.Persistence;
using Docsy.Endpoints.Slices.Schemas.Mapper;
using Docsy.Endpoints.Slices.Schemas.Models;
using StackExchange.Redis;

namespace Docsy.Endpoints.Slices.Schemas;

internal sealed class SchemaStageWriter : IDataWriter<Schema>
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public SchemaStageWriter(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<Schema> WriteEntity(Schema obj)
    {
        var database = _connectionMultiplexer.GetDatabase();
        var redisKey = obj.SchemaId.CollectionId.Value.ToString();
        var stagedValues = await database.StringGetAsync(redisKey);
        if (!string.IsNullOrWhiteSpace(stagedValues.ToString()))
        {
            var stage = JsonSerializer.Deserialize<ICollection<Schema>>(
                stagedValues.ToString(),
                options: StageJsonSerializerOptions.SharedOptions);
            if (stage is not null)
            {
                var target = stage.FirstOrDefault(schema =>
                    schema.SchemaId == obj.SchemaId);
                if (target is null)
                {
                    stage.Add(obj);
                }
                else
                {
                    SchemaMapper.Map(obj, target);
                }

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
