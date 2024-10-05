using System.Linq.Expressions;
using Assignments.Application.Assignments.Dtos;
using Assignments.Application.Common.Specifications;
using Assignments.Domain.Assignments;

namespace Assignments.Application.Assignments.Specifications;

public class IsSatisfiedAssignmentByFilterSpecification : Specification<Assignment>
{
    private readonly AssignmentFilter _filter;

    public IsSatisfiedAssignmentByFilterSpecification(AssignmentFilter filter)
    {
        _filter = filter;
    }

    public override Expression<Func<Assignment, bool>> ToExpression()
    {
        return x => 
        (
            x.Name.Contains(_filter.Name) &&
            (_filter.StatusId != 0 ? x.Status.Id == _filter.StatusId : true) 
        );
    }
}
