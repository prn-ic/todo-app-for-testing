using Assignments.Application.Assignments.Dtos;
using MediatR;

namespace Assignments.Application.Assignments.Commands.CreateAssignment;

public class CreateAssignmentCommand : IRequest<AssignmentDto>
{
    public AssignmentDto Assignment { get; set; }

    public CreateAssignmentCommand(AssignmentDto assignment)
    {
        Assignment = assignment;
    }
}
