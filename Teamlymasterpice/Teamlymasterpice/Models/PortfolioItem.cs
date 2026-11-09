using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class PortfolioItem
{
    public int Id { get; set; }

    public int ProviderId { get; set; }

    public string MediaType { get; set; } = null!;

    public string FileUrl { get; set; } = null!;

    public virtual Provider Provider { get; set; } = null!;
}
