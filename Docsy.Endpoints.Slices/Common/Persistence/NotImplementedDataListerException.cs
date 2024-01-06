using Docsy.Endpoints.Slices.Common.Exception;

namespace Docsy.Endpoints.Slices.Common.Persistence;

public sealed class NotImplementedDataListerException : InternalError
{
    public NotImplementedDataListerException(Type entity, Type key)
        : base($"There is no data lister of {entity.Name} having {key.Name}")
    {
        throw new NotImplementedException();
    }
}
