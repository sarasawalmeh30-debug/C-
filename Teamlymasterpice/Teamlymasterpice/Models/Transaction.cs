using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int PayerId { get; set; }

    public decimal Amount { get; set; }

    public decimal Commission { get; set; }

    public string Method { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual User Payer { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
