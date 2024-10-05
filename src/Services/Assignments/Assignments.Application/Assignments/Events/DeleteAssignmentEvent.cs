using MediatR;

namespace Assignments.Application.Assignments.Events;

public class DeleteAssignmentEvent : INotification
{
    public int Id { get; }
    public DeleteAssignmentEvent(int id)
    {
        Id = id;
    }
}
