using System;
using System.Collections.Generic;

namespace tasksara.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string NameEmployee { get; set; } = null!;

    public string EmailEmployee { get; set; } = null!;

    public string PasswordEmployee { get; set; } = null!;

    public int ManagerId { get; set; }

    public virtual Manager Manager { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
