using Assignments.Application.Assignments.Events;
using Assignments.Domain.Assignments;
using Assignments.Infrastructure.Data;
using MediatR;

namespace Assignments.Infrastructure.EventHandlers.Assignments;

public class UpdateAssignmentEventHandler : INotificationHandler<UpdateAssignmentEvent>
{
    private readonly AppDbContext _context;
    public UpdateAssignmentEventHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateAssignmentEvent notification, CancellationToken cancellationToken)
    {
        AssignmentStatus status = await _context.AssignmentStatuses
            .FindAsync(notification.Assignment.Status!.Id, cancellationToken)
            ?? throw new InvalidDataException("not found");
        notification.Assignment.SetStatus(status);
        _context.Assignments.Update(notification.Assignment);
    }
}
