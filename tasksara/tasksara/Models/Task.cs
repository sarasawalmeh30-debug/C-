using System;
using System.Collections.Generic;

namespace tasksara.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string TaskName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
