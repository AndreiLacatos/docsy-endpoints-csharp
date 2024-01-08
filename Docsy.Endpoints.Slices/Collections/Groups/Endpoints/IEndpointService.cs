using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Models;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints;

public interface IEndpointService
{
    Task<IEnumerable<Endpoint>> GetGroupEndpoints(GroupId groupId);
    Task<IEnumerable<Endpoint>> GetStagedGroupEndpoints(GroupId groupId);
}
