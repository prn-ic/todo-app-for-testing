using Assignments.Application.Assignments.Dtos;
using Assignments.Domain.Assignments;
using MediatR;

namespace Assignments.Application.Assignments.Queries.GetAssignments;

public class GetAssignmentsQuery : IRequest<IEnumerable<AssignmentDto>>
{
    
}