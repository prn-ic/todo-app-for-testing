using MediatR;

namespace Assignments.Domain.Assignments.Events.AssignmentEvents;

public class UpdateAssignmentDescriptionEvent : INotification
{
    public Assignment Assignment { get; }

    public UpdateAssignmentDescriptionEvent(Assignment assignment)
    {
        Assignment = assignment;
    }
}
