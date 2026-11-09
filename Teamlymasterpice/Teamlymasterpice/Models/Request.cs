using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class Request
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int ProviderId { get; set; }

    public int ServiceId { get; set; }

    public string? Description { get; set; }

    public DateOnly? EventDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly? Deadline { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Provider Provider { get; set; } = null!;

    public virtual Review? Review { get; set; }

    public virtual Service Service { get; set; } = null!;
}
