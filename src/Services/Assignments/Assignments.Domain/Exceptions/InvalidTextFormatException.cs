namespace Assignments.Domain.Exceptions;

public class InvalidTextFormatException : DomainException
{
    private string _field;
    public override string Message => $"Неверное поле {_field}";
    public InvalidTextFormatException(string field)
    {
        _field = field;
    }
}