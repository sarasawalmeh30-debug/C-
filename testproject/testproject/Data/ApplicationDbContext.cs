using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using testproject.Models;

namespace testproject.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<EmployeeProfile> EmployeeProfiles => Set<EmployeeProfile>();
    public DbSet<SupplierProfile> SupplierProfiles => Set<SupplierProfile>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ApplicationUser>().Property(x => x.FullName).HasDefaultValue(string.Empty);
        builder.Entity<ApplicationUser>().Property(x => x.UserType).HasDefaultValue("Employee");
        builder.Entity<ApplicationUser>().Property(x => x.IsActive).HasDefaultValue(true);
        builder.Entity<ApplicationUser>().Property(x => x.MustChangePassword).HasDefaultValue(false);
        builder.Entity<ApplicationUser>().Property(x => x.OnboardingStatus).HasDefaultValue("Completed");
        builder.Entity<ApplicationUser>().Property(x => x.FingerprintDemoCompleted).HasDefaultValue(false);
        builder.Entity<ApplicationUser>().Property(x => x.FaceDemoCompleted).HasDefaultValue(false);
        builder.Entity<IdentityUserLogin<string>>().Property(x => x.LoginProvider).HasMaxLength(128);
        builder.Entity<IdentityUserLogin<string>>().Property(x => x.ProviderKey).HasMaxLength(128);
        builder.Entity<IdentityUserToken<string>>().Property(x => x.LoginProvider).HasMaxLength(128);
        builder.Entity<IdentityUserToken<string>>().Property(x => x.Name).HasMaxLength(128);
        builder.Entity<EmployeeProfile>().HasIndex(x => x.UserId).IsUnique();
        builder.Entity<EmployeeProfile>().HasIndex(x => x.EmployeeNumber).IsUnique();
        builder.Entity<SupplierProfile>().HasIndex(x => x.UserId).IsUnique();
        builder.Entity<SupplierProfile>().HasIndex(x => x.TaxNumber).IsUnique();
        builder.Entity<EmployeeProfile>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<SupplierProfile>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
