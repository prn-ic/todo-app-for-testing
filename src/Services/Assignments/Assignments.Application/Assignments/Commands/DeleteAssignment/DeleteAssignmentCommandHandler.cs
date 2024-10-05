using Assignments.Application.Assignments.Events;
using Assignments.Application.Common.Contracts;
using Assignments.Domain.Assignments;
using MediatR;

namespace Assignments.Application.Assignments.Commands.DeleteAssignment;

public class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAssignmentCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
    {
        Assignment assignment =
            await _unitOfWork.QuerySingleAsync<Assignment>(
                x => x.Id == request.Id,
                cancellationToken
            ) ?? throw new InvalidDataException("Задача не найдена");
        assignment.AddDomainEvent(new DeleteAssignmentEvent(request.Id));
        await _unitOfWork.SaveChangesAsync(new() { assignment }, cancellationToken);
    }
}
