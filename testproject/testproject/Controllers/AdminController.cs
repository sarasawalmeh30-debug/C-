using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testproject.Models;

namespace testproject.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController(UserManager<ApplicationUser> users, RoleManager<IdentityRole> roles) : Controller
{
    private static readonly string[] StaffRoles =
        ["SourcingManager", "SourcingOfficer", "EvaluationCommittee", "TopCommittee"];

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var rows = new List<StaffAccountRow>();
        foreach (var user in await users.Users.OrderBy(x => x.FullName).ToListAsync())
        {
            var role = (await users.GetRolesAsync(user)).FirstOrDefault() ?? user.UserType;
            rows.Add(new StaffAccountRow
            {
                FullName = user.FullName,
                Email = user.Email ?? string.Empty,
                Role = RoleLabel(role),
                OnboardingStatus = user.OnboardingStatus
            });
        }
        return View(rows);
    }

    [HttpGet]
    public IActionResult Create() => View(new StaffAccountViewModel());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StaffAccountViewModel model)
    {
        if (!StaffRoles.Contains(model.Role))
            ModelState.AddModelError(nameof(model.Role), "Choose one of the staff roles.");
        if (!ModelState.IsValid) return View(model);
        if (await users.FindByEmailAsync(model.Email) != null)
        {
            ModelState.AddModelError(nameof(model.Email), "An account already uses this email.");
            return View(model);
        }
        if (!await roles.RoleExistsAsync(model.Role))
        {
            var roleResult = await roles.CreateAsync(new IdentityRole(model.Role));
            if (!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors) ModelState.AddModelError(string.Empty, error.Description);
                return View(model);
            }
        }

        var user = new ApplicationUser
        {
            UserName = model.Email.Trim(),
            Email = model.Email.Trim(),
            EmailConfirmed = true,
            FullName = model.FullName.Trim(),
            UserType = "Employee",
            JobTitle = string.IsNullOrWhiteSpace(model.JobTitle) ? RoleLabel(model.Role) : model.JobTitle.Trim(),
            IsActive = true,
            MustChangePassword = true,
            OnboardingStatus = "NotStarted"
        };
        var createResult = await users.CreateAsync(user, model.TemporaryPassword);
        if (!createResult.Succeeded)
        {
            foreach (var error in createResult.Errors) ModelState.AddModelError(string.Empty, error.Description);
            return View(model);
        }

        var assignResult = await users.AddToRoleAsync(user, model.Role);
        if (!assignResult.Succeeded)
        {
            await users.DeleteAsync(user);
            foreach (var error in assignResult.Errors) ModelState.AddModelError(string.Empty, error.Description);
            return View(model);
        }

        TempData["CreatedAccount"] = $"Account created for {user.FullName}. Give them the temporary password you entered.";
        return RedirectToAction(nameof(Index));
    }

    public static string RoleLabel(string role) => role switch
    {
        "SourcingManager" => "Sourcing Manager",
        "SourcingOfficer" => "Sourcing Officer",
        "EvaluationCommittee" => "Committee",
        "TopCommittee" => "Top Committee",
        "Admin" => "Administrator",
        "Supplier" => "Supplier",
        _ => role
    };
}
