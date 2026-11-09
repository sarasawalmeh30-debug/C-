using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class AiMessage
{
    public int Id { get; set; }

    public int ConversationId { get; set; }

    public string Sender { get; set; } = null!;

    public string Body { get; set; } = null!;

    public DateTime SentAt { get; set; }

    public virtual AiConversation Conversation { get; set; } = null!;
}
