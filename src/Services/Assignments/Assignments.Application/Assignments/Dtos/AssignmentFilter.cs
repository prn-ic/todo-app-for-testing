namespace Assignments.Application.Assignments.Dtos;

public class AssignmentFilter
{
    public int Take { get; set; }
    public int Skip { get; set; }
    public string Name { get; set; } = "";
    public int StatusId { get; set; }
}
