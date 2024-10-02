using Assignments.Application.Assignments.Dtos;
using MediatR;

namespace Assignments.Application.Assignments.Commands.UpdateAssignment;

public class UpdateAssignmentCommand : IRequest
{
    public AssignmentDto Assignment { get; set; }
    public UpdateAssignmentCommand(AssignmentDto assignment)
    {
        Assignment = assignment;
    }
}
