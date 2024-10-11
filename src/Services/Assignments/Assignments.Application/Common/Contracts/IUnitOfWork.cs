using System.Linq.Expressions;
using Assignments.Domain.Common;

namespace Assignments.Application.Common.Contracts;

public interface IUnitOfWork
{
    Task<IEnumerable<T>> QueryAsync<T>(
        Expression<Func<T, bool>> expression = null!,
        CancellationToken cancellationToken = default
    )
        where T : class, IBaseEntity;
    Task<T?> QuerySingleAsync<T>(
        Expression<Func<T, bool>> expression,
        CancellationToken cancellationToken = default
    )
        where T : class, IBaseEntity;
    Task<int> SaveChangesAsync(
        List<IBaseEntity> changedEntities,
        CancellationToken cancellationToken = default
    );
}
