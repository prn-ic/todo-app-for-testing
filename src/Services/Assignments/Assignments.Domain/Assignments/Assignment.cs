using Assignments.Domain.Assignments.Events.AssignmentEvents;
using Assignments.Domain.Common;
using Assignments.Domain.Exceptions;

namespace Assignments.Domain.Assignments;

public class Assignment : BaseEntity<int>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AssignmentStatus Status { get; private set; }
    protected Assignment() { }
    public Assignment(string name, string description, AssignmentStatus status)
    {
        if (string.IsNullOrEmpty(name))
            throw new InvalidTextFormatException("name");
        if (string.IsNullOrEmpty(description))
            throw new InvalidTextFormatException("description");

        Name = name;
        Description = description;
        Status = status;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new InvalidTextFormatException("name");
        Name = name;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
            throw new InvalidTextFormatException("description");
        Description = description;
    }

    public void SetStatus(AssignmentStatus status)
    {
        CheckStatusEquality(status);
        Status = status;
    }

    private void CheckStatusEquality(AssignmentStatus status)
    {
        if (Status is not null && Status.Name is not null && status.Name.ToLower().Equals(Status.Name.ToLower()))
            throw new AlreadySettedAssignmentStatusException(status);
    }
}
