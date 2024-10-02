using MediatR;

namespace Assignments.Domain.Common;

public interface IBaseEntity
{
    IReadOnlyCollection<INotification> DomainEvents { get; }
    void AddDomainEvent(INotification notification);
    void RemoveDomainEvent(INotification notification);
    void ClearDomainEvents();
}
