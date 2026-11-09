using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class SupportTicket
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string ContactEmail { get; set; } = null!;

    public string IssueType { get; set; } = null!;

    public string? Subject { get; set; }

    public string Message { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
