namespace DesafioAda.Exceptions;

public class EntityNotFoundException : SystemException
{
    public EntityNotFoundException() : base() { }
    public EntityNotFoundException(string message)
            : base(message)
    {
    }
}
