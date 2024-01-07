using Docsy.Endpoints.Slices.Common.Exception;

namespace Docsy.Endpoints.Slices.Common.Persistence;

public sealed class NotImplementedDataWriterException : InternalError
{
    public NotImplementedDataWriterException(Type entity)
        : base($"There is no data writer of {entity.Name}")
    {
    }
}
