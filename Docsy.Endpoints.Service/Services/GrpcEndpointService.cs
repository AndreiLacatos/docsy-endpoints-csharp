using ApiCollection;
using Docsy.Endpoints.Mapper;
using Docsy.Endpoints.Slices.Collections.Groups;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Schemas;
using Grpc.Core;
using EndpointService = ApiCollection.EndpointService;

namespace Docsy.Endpoints.Services;

public sealed class GrpcEndpointService : EndpointService.EndpointServiceBase
{
    private readonly IGroupService _groupService;
    private readonly IEndpointService _endpointService;
    private readonly ISchemaService _schemaService;
    private readonly ILogger<GrpcEndpointService> _logger;

    public GrpcEndpointService(
        IGroupService groupService,
        IEndpointService endpointService,
        ISchemaService schemaService,
        ILogger<GrpcEndpointService> logger)
    {
        _groupService = groupService;
        _endpointService = endpointService;
        _schemaService = schemaService;
        _logger = logger;
    }

    public override async Task<GetCollectionGroupsResponse> GetCollectionGroups(
        GetCollectionGroupsRequest request,
        ServerCallContext context)
    {
        var collectionId = CollectionId.FromName(request.Name);
        var groups = await _groupService.GetCollectionGroups(collectionId);
        return new GetCollectionGroupsResponse
        {
            Groups =
            {
                groups.Select(GrpcGroupMapper.Map),
            },
        };
    }

    public override async Task<GetCollectionGroupsResponse> GetStagedCollectionGroups(
        GetCollectionGroupsRequest request,
        ServerCallContext context)
    {
        var collectionId = CollectionId.FromName(request.Name);
        var groups = await _groupService.GetStagedCollectionGroups(collectionId);
        return new GetCollectionGroupsResponse
        {
            Groups =
            {
                groups.Select(GrpcGroupMapper.Map),
            },
        };
    }

    public override async Task<GetGroupEndpointsResponse> GetGroupEndpoints(
        GetGroupEndpointsRequest request,
        ServerCallContext context)
    {
        var groupId = GroupId.FromName(request.Name);
        var endpoints = await _endpointService.GetGroupEndpoints(groupId);
        return new GetGroupEndpointsResponse
        {
            Endpoints =
            {
                endpoints.Select(GrpcEndpointMapper.Map),
            },
        };
    }

    public override async Task<GetGroupEndpointsResponse> GetStagedGroupEndpoints(
        GetGroupEndpointsRequest request,
        ServerCallContext context)
    {
        var groupId = GroupId.FromName(request.Name);
        var endpoints = await _endpointService.GetStagedGroupEndpoints(groupId);
        return new GetGroupEndpointsResponse
        {
            Endpoints =
            {
                endpoints.Select(GrpcEndpointMapper.Map),
            },
        };
    }

    public override async Task<GetCollectionSchemasResponse> GetCollectionSchemas(
        GetCollectionSchemasRequest request,
        ServerCallContext context)
    {
        var collectionId = CollectionId.FromName(request.Name);
        var schemas = await _schemaService.GetCollectionSchemas(collectionId);
        return new GetCollectionSchemasResponse
        {
            Schemas =
            {
                schemas.Select(GrpcSchemaMapper.Map),
            },
        };
    }

    public override async Task<GetCollectionSchemasResponse> GetStagedCollectionSchemas(
        GetCollectionSchemasRequest request,
        ServerCallContext context)
    {
        var collectionId = CollectionId.FromName(request.Name);
        var schemas = await _schemaService.GetStagedCollectionSchemas(collectionId);
        return new GetCollectionSchemasResponse
        {
            Schemas =
            {
                schemas.Select(GrpcSchemaMapper.Map),
            },
        };
    }

    public override async Task<CollectionGroup> CreateGroup(
        CollectionGroup request,
        ServerCallContext context)
    {
        var groupToCreate = GrpcGroupMapper.Map(request);
        var createdGroup = await _groupService.CreateGroup(groupToCreate);
        return GrpcGroupMapper.Map(createdGroup);
    }

    public override async Task<StageGroupChangeResponse> StageGroupChange(
        StageGroupChangeRequest request,
        ServerCallContext context)
    {
        var stagedChanges = await _groupService
            .StageGroupChanges(GrpcGroupMapper.Map(request));
        return GrpcGroupMapper.Map(stagedChanges);
    }

    public override async Task StageEndpointChange(
        IAsyncStreamReader<StageEndpointChangeRequest> requestStream,
        IServerStreamWriter<StageEndpointChangeResponse> responseStream,
        ServerCallContext context)
    {
        await foreach (var message in requestStream.ReadAllAsync())
        {
            try
            {
                var changeRequest = new EndpointChangeSet
                {
                    EndpointId = EndpointId.FromName(message.Target),
                    Endpoint =  GrpcEndpointMapper.Map(message.ChangeSet),
                    Type = GrpcEndpointMapper.MapChangeSetType(message.Mode),
                };
                var result = await _endpointService.StageEndpointChange(changeRequest);
                await responseStream.WriteAsync(new StageEndpointChangeResponse
                {
                    ChangeSet = GrpcEndpointMapper.Map(result),
                    Target = message.Target,
                    Mode = message.Mode,
                    RequestKey = message.RequestKey,
                });
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, "Unexpected error whilst staging content change");
            }
        }
    }
}
