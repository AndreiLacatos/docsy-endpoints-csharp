using Docsy.Endpoints.Slices.Common.Exception;

namespace Docsy.Endpoints.Slices.Common.Persistence;

public sealed class NotImplementedDataReaderException : InternalError
{
    public NotImplementedDataReaderException(Type entity, Type key)
        : base($"There is no data reader of {entity.Name} having {key.Name}")
    {
    }
}
