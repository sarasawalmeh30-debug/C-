using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using task8.Models;

namespace task8.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

     

        public DbSet<Product> products { get; set; }

        public DbSet<SupplyRequest> supplyRequests { get; set; }

        public DbSet<RequestItem> requestItems { get; set; }

    }
}
