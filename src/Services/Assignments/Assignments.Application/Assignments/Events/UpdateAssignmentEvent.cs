using Assignments.Application.Assignments.Dtos;
using Assignments.Domain.Assignments;
using MediatR;

namespace Assignments.Application.Assignments.Events;

public class UpdateAssignmentEvent : INotification
{
    public Assignment Assignment { get; set; }
    public UpdateAssignmentEvent(Assignment assignment)
    {
        Assignment = assignment;
    }
}
