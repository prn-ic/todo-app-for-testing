using MediatR;

namespace Assignments.Domain.Assignments.Events.AssignmentEvents;

public class UpdateAssignmentNameEvent : INotification
{
    public Assignment Assignment { get; }

    public UpdateAssignmentNameEvent(Assignment assignment)
    {
        Assignment = assignment;
    }
}
