using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class Message
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public string Body { get; set; } = null!;

    public DateTime SentAt { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual User Receiver { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
