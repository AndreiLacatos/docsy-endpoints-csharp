using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Mapper;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Common.Persistence;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints;

public sealed class EndpointService : IEndpointService
{
    private readonly IDataLister<EndpointEntity, GroupId> _endpointLister;
    private readonly IDataLister<Endpoint, GroupId> _endpointStageLister;
    private readonly IDataWriter<Endpoint> _endpointStageWriter;

    public EndpointService(
        IDataListerFactory dataListerFactory,
        IDataWriterFactory dataWriterFactory)
    {
        _endpointLister = dataListerFactory.GetLister<EndpointEntity, GroupId>();
        _endpointStageLister = dataListerFactory.GetStageLister<Endpoint, GroupId>();
        _endpointStageWriter = dataWriterFactory.GetStageWriter<Endpoint>();
    }

    public async Task<IEnumerable<Endpoint>> GetGroupEndpoints(GroupId groupId)
    {
        var endpoints = await _endpointLister.ListEntities(groupId);
        return endpoints.Select(EndpointMapper.Map);
    }

    public async Task<IEnumerable<Endpoint>> GetStagedGroupEndpoints(GroupId groupId)
    {
        var endpoints = await _endpointStageLister.ListEntities(groupId);
        endpoints = endpoints.ToArray();
        if (!endpoints.Any())
        {
            endpoints = await GetGroupEndpoints(groupId);
            endpoints = endpoints.ToArray();
            foreach (var item in endpoints)
            {
                await _endpointStageWriter.WriteEntity(item);
            }
        }

        return endpoints;
    }
}
