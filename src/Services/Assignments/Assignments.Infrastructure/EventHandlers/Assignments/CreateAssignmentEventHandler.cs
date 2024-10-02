using Assignments.Application.Assignments.Events;
using Assignments.Domain.Assignments;
using Assignments.Infrastructure.Data;
using MediatR;

namespace Assignments.Infrastructure.EventHandlers.Assignments;

public class CreateAssignmentEventHandler : INotificationHandler<CreateAssignmentEvent>
{
    private readonly AppDbContext _context;

    public CreateAssignmentEventHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateAssignmentEvent notification, CancellationToken cancellationToken)
    {
        AssignmentStatus status = await _context.AssignmentStatuses
            .FindAsync(notification.Assignment.Status!.Id)
            ?? throw new InvalidDataException("not found");
        notification.Assignment.SetStatus(status);
        await _context.AddAsync(notification.Assignment);
    }
}