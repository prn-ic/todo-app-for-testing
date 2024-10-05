using System.Linq.Expressions;
using Assignments.Application.Common.Contracts;
using Assignments.Domain.Assignments;
using Assignments.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Assignments.Infrastructure.Data;

public class AppDbContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;
    public virtual DbSet<Assignment> Assignments => Set<Assignment>();
    public virtual DbSet<AssignmentStatus> AssignmentStatuses => Set<AssignmentStatus>();

    public AppDbContext(IMediator mediator, DbContextOptions options)
        : base(options)
    {
        _mediator = mediator;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assignment>().Navigation(a => a.Status).AutoInclude();
        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> SaveChangesAsync(
        List<IBaseEntity> changedEntities,
        CancellationToken cancellationToken = default
    )
    {
        foreach (var changedEntity in changedEntities)
        {
            foreach (var domainEvent in changedEntity.DomainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(
        Expression<Func<T, bool>> expression = null!,
        CancellationToken cancellationToken = default
    )
        where T : class, IBaseEntity
    {
        return expression is not null
            ? await Set<T>().Where(expression).ToListAsync(cancellationToken)
            : await Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T?> QuerySingleAsync<T>(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        where T : class, IBaseEntity
    {
        return (await QueryAsync<T>(expression, cancellationToken)).FirstOrDefault();
    }
}
