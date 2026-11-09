using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class ProviderService
{
    public int ProviderId { get; set; }

    public int ServiceId { get; set; }

    public bool IsMain { get; set; }

    public virtual Provider Provider { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
