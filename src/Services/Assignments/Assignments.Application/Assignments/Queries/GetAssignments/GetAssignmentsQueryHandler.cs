using Assignments.Application.Assignments.Dtos;
using Assignments.Application.Common.Contracts;
using Assignments.Application.Common.Specifications;
using Assignments.Domain.Assignments;
using AutoMapper;
using MediatR;

namespace Assignments.Application.Assignments.Queries.GetAssignments;

public class GetAssignmentsQueryHandler
    : IRequestHandler<GetAssignmentsQuery, IEnumerable<AssignmentDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAssignmentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AssignmentDto>> Handle(
        GetAssignmentsQuery request,
        CancellationToken cancellationToken
    )
    {
        var result = await _unitOfWork.QueryAsync(
            new EmptySpecification<Assignment>().ToExpression(),
            cancellationToken
        );
        
        return _mapper.Map<IEnumerable<AssignmentDto>>(result);
    }
}
