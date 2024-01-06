using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Common.Exception;

namespace Docsy.Endpoints.Slices.Collections;

public sealed class CollectionNotFoundException : NotFoundException
{
    public CollectionNotFoundException(CollectionId collectionId)
        : base(typeof(Collection), collectionId.GetName())
    {
    }
}
