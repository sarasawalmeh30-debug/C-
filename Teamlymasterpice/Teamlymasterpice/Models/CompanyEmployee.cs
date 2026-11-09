using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class CompanyEmployee
{
    public int Id { get; set; }

    public int ProviderId { get; set; }

    public string Name { get; set; } = null!;

    public string? Specialty { get; set; }

    public virtual Provider Provider { get; set; } = null!;
}
