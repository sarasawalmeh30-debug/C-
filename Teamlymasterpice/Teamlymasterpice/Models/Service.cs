using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProviderService> ProviderServices { get; set; } = new List<ProviderService>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
