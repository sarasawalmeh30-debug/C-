using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class Project
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public string Name { get; set; } = null!;

    public string EventType { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateOnly? EventDate { get; set; }

    public decimal Budget { get; set; }

    public string Status { get; set; } = null!;

    public virtual User Client { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
