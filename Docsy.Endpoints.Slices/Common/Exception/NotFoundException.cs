namespace Docsy.Endpoints.Slices.Common.Exception;

public abstract class NotFoundException : System.Exception
{
    protected NotFoundException(Type entity, string entityId)
        : base($"{entity.Name} with id {entityId} not found")
    {
    }
}
