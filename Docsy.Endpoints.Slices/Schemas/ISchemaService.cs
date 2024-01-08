using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Schemas.Models;

namespace Docsy.Endpoints.Slices.Schemas;

public interface ISchemaService
{
    Task<IEnumerable<Schema>> GetCollectionSchemas(CollectionId collectionId);
    Task<IEnumerable<Schema>> GetStagedCollectionSchemas(CollectionId collectionId);
}
