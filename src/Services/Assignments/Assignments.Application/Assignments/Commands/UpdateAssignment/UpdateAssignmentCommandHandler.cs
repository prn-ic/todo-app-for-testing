using Assignments.Application.Assignments.Events;
using Assignments.Application.Common.Contracts;
using Assignments.Domain.Assignments;
using AutoMapper;
using MediatR;

namespace Assignments.Application.Assignments.Commands.UpdateAssignment;

public class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateAssignmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
    {
        Assignment assignment = _mapper.Map<Assignment>(request.Assignment);
        assignment.AddDomainEvent(new UpdateAssignmentEvent(assignment));
        await _unitOfWork.SaveChangesAsync(new() { assignment }, cancellationToken);
    }
}
