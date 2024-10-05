using Assignments.Application.Assignments.Events;
using Assignments.Domain.Assignments;
using Assignments.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Assignments.Infrastructure.EventHandlers.Assignments;

public class DeleteAssignmentEventHandler : INotificationHandler<DeleteAssignmentEvent>
{
    private readonly AppDbContext _context;
    public DeleteAssignmentEventHandler(AppDbContext context)
    {
        _context = context;
    }
    public async Task Handle(DeleteAssignmentEvent notification, CancellationToken cancellationToken)
    {
        Assignment assignment = await _context.Assignments.FirstAsync(x => x.Id == notification.Id, cancellationToken);
        _context.Assignments.Remove(assignment);
    }
}