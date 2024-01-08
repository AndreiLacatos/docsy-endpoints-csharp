using System.Text.Json;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Mapper;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Common.Persistence;
using StackExchange.Redis;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints;

internal sealed class EndpointStageWriter : IDataWriter<Endpoint>
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public EndpointStageWriter(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<Endpoint> WriteEntity(Endpoint obj)
    {
        var database = _connectionMultiplexer.GetDatabase();
        var redisKey = obj.EndpointId.GroupId.Value.ToString();
        var stagedValues = await database.StringGetAsync(redisKey);
        if (!string.IsNullOrWhiteSpace(stagedValues.ToString()))
        {
            var stage = JsonSerializer.Deserialize<ICollection<Endpoint>>(
                stagedValues.ToString(),
                options: StageJsonSerializerOptions.SharedOptions);
            if (stage is not null)
            {
                var target = stage.FirstOrDefault(
                    endpoint => endpoint.EndpointId == obj.EndpointId);

                if (target is null)
                {
                    stage.Add(obj);
                }
                else
                {
                    EndpointMapper.Map(obj, target);
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
