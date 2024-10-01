using Assignments.Domain.Assignments;

namespace Assignments.Domain.Exceptions;

public class AlreadySettedAssignmentStatusException : DomainException
{
    private string _statusName;
    public override string Message => $"Невозможно перевести в статус '{_statusName}', так как задача уже выполнена";
    public AlreadySettedAssignmentStatusException(AssignmentStatus status)
    {
        _statusName = status.ToString();
    }
}