namespace Docsy.Endpoints.Slices.Common.Exception;

public abstract class InternalError : System.Exception
{
    protected InternalError(string message)
        : base(message)
    {
    }
}
