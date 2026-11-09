using System;
using System.Collections.Generic;

namespace Teamlymasterpice.Models;

public partial class Provider
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string ProviderType { get; set; } = null!;

    public string? CompanyName { get; set; }

    public string? RepresentativeName { get; set; }

    public string? BusinessEmail { get; set; }

    public string? Tagline { get; set; }

    public string Location { get; set; } = null!;

    public string? Description { get; set; }

    public decimal StartingPrice { get; set; }

    public string PricingUnit { get; set; } = null!;

    public int PricingQuantity { get; set; }

    public virtual ICollection<CompanyEmployee> CompanyEmployees { get; set; } = new List<CompanyEmployee>();

    public virtual ICollection<PortfolioItem> PortfolioItems { get; set; } = new List<PortfolioItem>();

    public virtual ICollection<ProviderService> ProviderServices { get; set; } = new List<ProviderService>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual User User { get; set; } = null!;
}
