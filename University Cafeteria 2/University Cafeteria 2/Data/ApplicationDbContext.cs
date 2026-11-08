using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using University_Cafeteria_2.Models;

namespace University_Cafeteria_2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category_model> Categories { get; set; }
        public DbSet<Product_model> Products { get; set; }
        public DbSet<Supplier_model> Suppliers { get; set; }
    }
}
