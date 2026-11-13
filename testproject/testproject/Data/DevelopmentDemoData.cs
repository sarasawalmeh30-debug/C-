using Microsoft.AspNetCore.Identity;
using testproject.Models;

namespace testproject.Data;

public static class DevelopmentDemoData
{
    private sealed record DemoUser(string FullName, string Email, string Password, string Role, string UserType, bool MustChangePassword);

    private static readonly string[] Roles =
    ["Admin", "Supplier", "SourcingManager", "SourcingOfficer", "EvaluationCommittee", "TopCommittee"];

    private static readonly DemoUser[] Users =
    [
        new("Demo Admin", "admin@demo.local", "Admin@12345", "Admin", "Employee", false),
        new("Sourcing Manager Demo", "manager@demo.local", "Demo@12345", "SourcingManager", "Employee", true),
        new("Sourcing Officer Demo", "officer@demo.local", "Demo@12345", "SourcingOfficer", "Employee", true),
        new("Committee Demo", "committee@demo.local", "Demo@12345", "EvaluationCommittee", "Employee", true),
        new("Top Committee Demo", "topcommittee@demo.local", "Demo@12345", "TopCommittee", "Employee", true)
    ];

    public static async Task SeedAsync(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        foreach (var role in Roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(role));
                if (!result.Succeeded)
                    throw new InvalidOperationException($"Could not create role {role}: {string.Join(", ", result.Errors.Select(x => x.Description))}");
            }
        }

        foreach (var demo in Users)
        {
            var user = await userManager.FindByEmailAsync(demo.Email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = demo.Email,
                    Email = demo.Email,
                    EmailConfirmed = true,
                    FullName = demo.FullName,
                    UserType = demo.UserType,
                    JobTitle = demo.Role,
                    IsActive = true,
                    MustChangePassword = demo.MustChangePassword,
                    OnboardingStatus = demo.MustChangePassword ? "NotStarted" : "Completed"
                };
                var create = await userManager.CreateAsync(user, demo.Password);
                if (!create.Succeeded)
                    throw new InvalidOperationException($"Could not create demo account {demo.Email}: {string.Join(", ", create.Errors.Select(x => x.Description))}");
            }

            if (!await userManager.IsInRoleAsync(user, demo.Role))
            {
                var assign = await userManager.AddToRoleAsync(user, demo.Role);
                if (!assign.Succeeded)
                    throw new InvalidOperationException($"Could not assign {demo.Role} to {demo.Email}: {string.Join(", ", assign.Errors.Select(x => x.Description))}");
            }
        }
    }
}
