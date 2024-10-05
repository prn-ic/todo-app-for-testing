using Assignments.Application.Assignments.Dtos;
using Assignments.Application.Assignments.Specifications;
using Assignments.Application.Common.Contracts;
using AutoMapper;
using MediatR;

namespace Assignments.Application.Assignments.Queries.GetFilteredAssignments;

public class GetFilteredAssignmentsQueryHandler
    : IRequestHandler<GetFilteredAssignmentsQuery, IEnumerable<AssignmentDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetFilteredAssignmentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AssignmentDto>> Handle(
        GetFilteredAssignmentsQuery request,
        CancellationToken cancellationToken
    )
    {
        AssignmentFilter filter =
            new()
            {
                Take = request.Take,
                Skip = request.Skip,
                Name = request.Name,
                StatusId = request.StatusId,
            };

        var assignments = await _unitOfWork.QueryAsync(
            new IsSatisfiedAssignmentByFilterSpecification(filter).ToExpression(),
            cancellationToken
        );
        
        return _mapper.Map<IEnumerable<AssignmentDto>>(assignments);
    }
}
