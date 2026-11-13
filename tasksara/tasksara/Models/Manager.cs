using System;
using System.Collections.Generic;

namespace tasksara.Models;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string NameManager { get; set; } = null!;

    public string EmailManager { get; set; } = null!;

    public string PasswordManager { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
