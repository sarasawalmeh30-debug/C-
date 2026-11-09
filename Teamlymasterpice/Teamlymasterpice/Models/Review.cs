using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class Review
{
    public int Id { get; set; }

    public int RequestId { get; set; }

    public byte Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Request Request { get; set; } = null!;
}
