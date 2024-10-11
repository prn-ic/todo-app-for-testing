
using System.Linq.Expressions;

namespace Assignments.Application.Common.Specifications;

public class EmptySpecification<T> : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return x => true;
    }
}