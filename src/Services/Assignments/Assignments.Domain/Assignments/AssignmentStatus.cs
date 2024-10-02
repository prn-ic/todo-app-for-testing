using System.ComponentModel;
using Assignments.Domain.Common;
using Assignments.Domain.Exceptions;

namespace Assignments.Domain.Assignments;

public class AssignmentStatus : BaseEntity<int>
{
    public string Name { get; private set; }

    protected AssignmentStatus() { }
    public AssignmentStatus(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new InvalidTextFormatException("name");

        Name = name;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new InvalidTextFormatException("name");

        Name = name;
    }
}
