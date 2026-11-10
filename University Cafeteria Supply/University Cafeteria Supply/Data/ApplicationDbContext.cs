using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using University_Cafeteria_Supply.Models;

namespace University_Cafeteria_Supply.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductController> products { get; set; }

        public DbSet<SupplyRequest> supplyRequests { get; set; }

        public DbSet<RequestItem> requestItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SupplyRequest>()
                .Property(o => o.Status)
                .HasConversion<string>();
        }
    }
}
