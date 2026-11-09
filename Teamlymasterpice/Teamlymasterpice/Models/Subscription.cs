using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class Subscription
{
    public int Id { get; set; }

    public int ProviderId { get; set; }

    public int PlanId { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? RenewalDate { get; set; }

    public virtual SubscriptionPlan Plan { get; set; } = null!;

    public virtual Provider Provider { get; set; } = null!;
}
