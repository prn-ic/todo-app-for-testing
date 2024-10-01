using MediatR;

namespace Assignments.Domain.Assignments.Events.AssignmentEvents;

public class UpdateAssignmentStatusEvent : INotification
{
    public Assignment Assignment { get; }

    public UpdateAssignmentStatusEvent(Assignment assignment)
    {
        Assignment = assignment;
    }
}
