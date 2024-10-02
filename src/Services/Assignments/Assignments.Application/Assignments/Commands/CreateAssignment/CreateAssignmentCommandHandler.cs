using Assignments.Application.Assignments.Dtos;
using Assignments.Application.Assignments.Events;
using Assignments.Application.Common.Contracts;
using Assignments.Domain.Assignments;
using AutoMapper;
using MediatR;

namespace Assignments.Application.Assignments.Commands.CreateAssignment;

public class CreateAssignmentCommandHandler
    : IRequestHandler<CreateAssignmentCommand, AssignmentDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAssignmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AssignmentDto> Handle(
        CreateAssignmentCommand request,
        CancellationToken cancellationToken
    )
    {
        Assignment assignment = _mapper.Map<Assignment>(request.Assignment);
        assignment.AddDomainEvent(new CreateAssignmentEvent(assignment));
        await _unitOfWork.SaveChangesAsync(new() { assignment }, cancellationToken);
        
        return request.Assignment;
    }
}
