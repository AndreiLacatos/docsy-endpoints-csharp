using System.Text.Json;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Common.Persistence;
using StackExchange.Redis;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints;

internal sealed class EndpointStageLister : IDataLister<Endpoint, GroupId>
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public EndpointStageLister(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
    }

    public async Task<IEnumerable<Endpoint>> ListEntities(GroupId key)
    {
        var database = _connectionMultiplexer.GetDatabase();
        var redisKey = key.Value.ToString();
        var stagedValues = await database.StringGetAsync(redisKey);
        if (!string.IsNullOrWhiteSpace(stagedValues.ToString()))
        {
            var stage = JsonSerializer.Deserialize<ICollection<Endpoint>>(
                stagedValues.ToString(),
                options: StageJsonSerializerOptions.SharedOptions);
            if (stage is not null)
            {
                return stage;
            }
        }

        return Enumerable.Empty<Endpoint>();
    }
}
