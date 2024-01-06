using Docsy.Endpoints.Slices.Common.Exception;

namespace Docsy.Endpoints.Slices.Common.Persistence;

public sealed class UnknownEntityException : InternalError
{
    public UnknownEntityException(string entityName)
        : base($"Unknown entity {entityName}")
    {
    }
}
