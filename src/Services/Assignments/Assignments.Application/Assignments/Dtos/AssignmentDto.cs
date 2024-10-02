namespace Assignments.Application.Assignments.Dtos;

public class AssignmentDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public AssignmentStatusDto? Status { get; set; }
    public int StatusId { get; set; } 
    public AssignmentDto()
    {
        if (Status is not null)
            StatusId = Status.Id;
    }
}