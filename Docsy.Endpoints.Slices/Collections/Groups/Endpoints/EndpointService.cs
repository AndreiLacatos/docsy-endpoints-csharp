using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Mapper;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Common.Persistence;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints;

public sealed class EndpointService : IEndpointService
{
    private readonly IDataLister<EndpointEntity, GroupId> _endpointLister;

    public EndpointService(IDataListerFactory dataListerFactory)
    {
        _endpointLister = dataListerFactory.GetLister<EndpointEntity, GroupId>();
    }

    public async Task<IEnumerable<Endpoint>> GetGroupEndpoints(GroupId groupId)
    {
        var endpoints = await _endpointLister.ListEntities(groupId);
        return endpoints.Select(EndpointMapper.Map);
    }
}
