using MediatR;

namespace Assignments.Domain.Common;

public abstract class BaseEntity<TPrimaryKey> where TPrimaryKey : struct 
{
    public TPrimaryKey Id { get; set; }
    private List<INotification> _domainEvents = new List<INotification>();
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents;
    public void AddDomainEvent(INotification notification)
    {
        _domainEvents.Add(notification);
    }
    public void RemoveDomainEvent(INotification notification)
    {
        _domainEvents.Remove(notification);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}