using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class AiConversation
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<AiMessage> AiMessages { get; set; } = new List<AiMessage>();

    public virtual User User { get; set; } = null!;
}
