using Assignments.Application.Assignments.Dtos;
using MediatR;

namespace Assignments.Application.Assignments.Queries.GetFilteredAssignments;

public class GetFilteredAssignmentsQuery : IRequest<IEnumerable<AssignmentDto>>
{
    public int Take { get; set; }
    public int Skip { get; set; }
    public string Name { get; set; } = "";
    public int StatusId { get; set; }
}