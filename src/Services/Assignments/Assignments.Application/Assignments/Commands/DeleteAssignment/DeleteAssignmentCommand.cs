using MediatR;

namespace Assignments.Application.Assignments.Commands.DeleteAssignment;

public class DeleteAssignmentCommand : IRequest
{
    public int Id { get; }
    public DeleteAssignmentCommand(int id)
    {
        Id = id;
    }
}
