using Assignments.Application.Assignments.Commands.CreateAssignment;
using Assignments.Application.Assignments.Commands.DeleteAssignment;
using Assignments.Application.Assignments.Commands.UpdateAssignment;
using Assignments.Application.Assignments.Dtos;
using Assignments.Application.Assignments.Queries.GetAssignments;
using Assignments.Application.Assignments.Queries.GetFilteredAssignments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Assignments.Controllers.Controllers.Version1;

[ApiController]
[Route("api/v1/assignment")]
[ApiVersion("1.0")]
public class AssignmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssignmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAssignmentsQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetFiltered(
        CancellationToken cancellationToken,
        int take = 0,
        int skip = 0,
        string name = "",
        int statusId = 0
    )
    {
        var result = await _mediator.Send(
            new GetFilteredAssignmentsQuery()
            {
                Take = take,
                Skip = skip,
                Name = name,
                StatusId = statusId,
            },
            cancellationToken
        );

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        AssignmentDto assignmentDto,
        CancellationToken cancellationToken
    )
    {
        await _mediator.Send(new CreateAssignmentCommand(assignmentDto), cancellationToken);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        AssignmentDto assignmentDto,
        CancellationToken cancellationToken
    )
    {
        await _mediator.Send(new UpdateAssignmentCommand(assignmentDto), cancellationToken);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteAssignmentCommand(id), cancellationToken);
        return Ok();
    }
}
