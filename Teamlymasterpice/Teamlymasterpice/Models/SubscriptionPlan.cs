using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class SubscriptionPlan
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ProviderType { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
