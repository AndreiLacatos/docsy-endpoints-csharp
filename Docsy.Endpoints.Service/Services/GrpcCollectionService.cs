using ApiCollection;
using Docsy.Endpoints.Mapper;
using Docsy.Endpoints.Slices.Collections;
using Docsy.Endpoints.Slices.Collections.Models;
using Grpc.Core;
using CollectionService = ApiCollection.CollectionService;

namespace Docsy.Endpoints.Services;

public sealed class GrpcCollectionService : CollectionService.CollectionServiceBase
{
    private readonly ICollectionService _collectionService;

    public GrpcCollectionService(ICollectionService collectionService)
    {
        _collectionService = collectionService;
    }

    public override async Task<ListProjectCollectionsResponse> ListProjectCollections(
        ListProjectCollectionsRequest request,
        ServerCallContext context)
    {
        var projectId = ProjectId.FromName(request.Name);
        var collections = await _collectionService.ListProjectCollections(projectId);
        return new ListProjectCollectionsResponse
        {
            Collections =
            {
                collections.Select(GrpcCollectionMapper.Map),
            },
        };
    }

    public override async Task<EndpointCollection> GetCollection(
        GetCollectionRequest request,
        ServerCallContext context)
    {
        var collectionId = CollectionId.FromName(request.Name);
        var collection = await _collectionService.GetCollection(collectionId);
        return GrpcCollectionMapper.Map(collection);
    }

    public override async Task<EndpointCollection> GetStagedCollection(
        GetCollectionRequest request,
        ServerCallContext context)
    {
        var collectionId = CollectionId.FromName(request.Name);
        var collection = await _collectionService.GetStagedCollection(collectionId);
        return GrpcCollectionMapper.Map(collection);
    }

    public override async Task<EndpointCollection> CreateCollection(
        EndpointCollection request,
        ServerCallContext context)
    {
        var collection = GrpcCollectionMapper.Map(request);
        var created = await _collectionService.CreateCollection(collection);
        return GrpcCollectionMapper.Map(created);
    }

    public override async Task<StageCollectionChangeResponse> StageCollectionChange(
        StageCollectionChangeRequest request,
        ServerCallContext context)
    {
        var staged = await _collectionService
            .StageCollectionChange(GrpcCollectionMapper.Map(request));
        return GrpcCollectionMapper.Map(staged);
    }
}
