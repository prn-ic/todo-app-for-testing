using System.ComponentModel;
using Assignments.Domain.Common;

namespace Assignments.Domain.Assignments;

public enum AssignmentStatus 
{
    [Description("Not Complete")]
    NotComplete = 1,
    [Description("On Work")]
    OnWork = 2,
    [Description("Complete")]
    Complete = 3
}
