using Assignments.Domain.Assignments;
using MediatR;

namespace Assignments.Application.Assignments.Events;

public class CreateAssignmentEvent : INotification
{
    public Assignment Assignment { get; }

    public CreateAssignmentEvent(Assignment assignment)
    {
        Assignment = assignment;
    }
}
