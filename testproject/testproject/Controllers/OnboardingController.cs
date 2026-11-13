using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testproject.Data;
using testproject.Models;

namespace testproject.Controllers;

[Authorize]
public class OnboardingController(UserManager<ApplicationUser> users, ApplicationDbContext db) : Controller
{
    public async Task<IActionResult> Index()
    {
        var user = await users.GetUserAsync(User);
        if (user == null) return Challenge();
        if (!user.IsActive) return Forbid();
        if (user.OnboardingStatus == "Completed") return RedirectToAction("Index", "Home");
        if (user.MustChangePassword) return RedirectToAction(nameof(ChangePassword));

        if (await IsSupplier(user))
        {
            var supplier = await db.SupplierProfiles.FirstOrDefaultAsync(x => x.UserId == user.Id);
            if (supplier == null || string.IsNullOrWhiteSpace(supplier.CompanyName)
                || string.IsNullOrWhiteSpace(supplier.TaxNumber)
                || string.IsNullOrWhiteSpace(supplier.CommercialRegNumber)
                || string.IsNullOrWhiteSpace(supplier.Country)
                || string.IsNullOrWhiteSpace(supplier.City)
                || string.IsNullOrWhiteSpace(supplier.Address)
                || string.IsNullOrWhiteSpace(supplier.ContactPerson)
                || string.IsNullOrWhiteSpace(supplier.ContactPhone)
                || string.IsNullOrWhiteSpace(supplier.Category)
                || string.IsNullOrWhiteSpace(user.FullName))
                return RedirectToAction(nameof(Supplier));
        }
        else
        {
            var employee = await db.EmployeeProfiles.FirstOrDefaultAsync(x => x.UserId == user.Id);
            if (employee == null || string.IsNullOrWhiteSpace(employee.EmployeeNumber)
                || employee.HireDate == default
                || string.IsNullOrWhiteSpace(employee.WorkPhone)
                || string.IsNullOrWhiteSpace(employee.PreferredLanguage)
                || string.IsNullOrWhiteSpace(user.FullName))
                return RedirectToAction(nameof(Profile));
        }

        if (!user.FingerprintDemoCompleted) return RedirectToAction(nameof(Fingerprint));
        if (!user.FaceDemoCompleted) return RedirectToAction(nameof(Face));
        if (user.BiometricDemoConsentAt == null) return RedirectToAction(nameof(Consent));

        await MarkComplete(user);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var user = await users.GetUserAsync(User);
        if (user == null) return Challenge();
        if (await IsSupplier(user)) return Forbid();
        ViewBag.RoleLabel = await GetRoleLabel(user);
        var profile = await db.EmployeeProfiles.FirstOrDefaultAsync(x => x.UserId == user.Id);
        return View(profile == null ? new EmployeeProfileViewModel { FullName = user.FullName } : new EmployeeProfileViewModel
        {
            FullName = user.FullName, EmployeeNumber = profile.EmployeeNumber, HireDate = profile.HireDate,
            WorkPhone = profile.WorkPhone, PreferredLanguage = profile.PreferredLanguage
        });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Profile(EmployeeProfileViewModel model)
    {
        var user = await users.GetUserAsync(User);
        if (user == null) return Challenge();
        if (await IsSupplier(user)) return Forbid();
        ViewBag.RoleLabel = await GetRoleLabel(user);
        if (!ModelState.IsValid) return View(model);
        if (await db.EmployeeProfiles.AnyAsync(x => x.EmployeeNumber == model.EmployeeNumber && x.UserId != user.Id))
        {
            ModelState.AddModelError(nameof(model.EmployeeNumber), "This employee number is already used.");
            return View(model);
        }
        user.FullName = model.FullName.Trim();
        await users.UpdateAsync(user);
        var profile = await db.EmployeeProfiles.FirstOrDefaultAsync(x => x.UserId == user.Id);
        if (profile == null) { profile = new EmployeeProfile { UserId = user.Id }; db.EmployeeProfiles.Add(profile); }
        profile.EmployeeNumber = model.EmployeeNumber.Trim(); profile.HireDate = model.HireDate;
        profile.WorkPhone = model.WorkPhone.Trim(); profile.PreferredLanguage = model.PreferredLanguage;
        profile.OnboardingCompletedAt = DateTime.UtcNow;
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Supplier()
    {
        var user = await users.GetUserAsync(User);
        if (user == null) return Challenge();
        if (!await IsSupplier(user)) return Forbid();
        ViewBag.RoleLabel = "Supplier";
        var profile = await db.SupplierProfiles.FirstOrDefaultAsync(x => x.UserId == user.Id);
        return View(profile == null ? new SupplierProfileViewModel { FullName = user.FullName } : new SupplierProfileViewModel
        {
            FullName = user.FullName, CompanyName = profile.CompanyName, TaxNumber = profile.TaxNumber,
            CommercialRegNumber = profile.CommercialRegNumber, Country = profile.Country,
            City = profile.City, Address = profile.Address, ContactPerson = profile.ContactPerson,
            ContactPhone = profile.ContactPhone, Website = profile.Website, Category = profile.Category
        });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Supplier(SupplierProfileViewModel model)
    {
        var user = await users.GetUserAsync(User);
        if (user == null) return Challenge();
        if (!await IsSupplier(user)) return Forbid();
        ViewBag.RoleLabel = "Supplier";
        if (!ModelState.IsValid) return View(model);
        if (await db.SupplierProfiles.AnyAsync(x => x.TaxNumber == model.TaxNumber && x.UserId != user.Id))
        {
            ModelState.AddModelError(nameof(model.TaxNumber), "This tax number is already registered.");
            return View(model);
        }
        user.FullName = model.FullName.Trim();
        await users.UpdateAsync(user);
        var profile = await db.SupplierProfiles.FirstOrDefaultAsync(x => x.UserId == user.Id);
        if (profile == null) { profile = new SupplierProfile { UserId = user.Id, Status = "Pending" }; db.SupplierProfiles.Add(profile); }
        profile.CompanyName = model.CompanyName.Trim(); profile.TaxNumber = model.TaxNumber.Trim();
        profile.CommercialRegNumber = model.CommercialRegNumber.Trim(); profile.Country = model.Country.Trim();
        profile.City = model.City.Trim(); profile.Address = model.Address.Trim();
        profile.ContactPerson = model.ContactPerson.Trim(); profile.ContactPhone = model.ContactPhone.Trim();
        profile.Website = string.IsNullOrWhiteSpace(model.Website) ? null : model.Website.Trim();
        profile.Category = model.Category.Trim();
        await db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Fingerprint()
    {
        var user = await users.GetUserAsync(User);
        if (user == null) return Challenge();
        if (user.FingerprintDemoCompleted) return RedirectToAction(nameof(Index));
        return View(new FingerprintDemoViewModel());
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Fingerprint(FingerprintDemoViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var user = await users.GetUserAsync(User);
        if (user == null) return Challenge();
        user.FingerprintDemoCompleted = true;
        await users.UpdateAsync(user);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Face()
    {
        var user = await users.GetUserAsync(User);
        if (user == null) return Challenge();
        if (user.FaceDemoCompleted) return RedirectToAction(nameof(Index));
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Face(bool continueDemo)
    {
        if (!continueDemo) return View();
        var user = await users.GetUserAsync(User);
        if (user == null) return Challenge();
        user.FaceDemoCompleted = true;
        await users.UpdateAsync(user);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Consent()
    {
        var user = await users.GetUserAsync(User);
        if (user == null) return Challenge();
        if (user.BiometricDemoConsentAt != null) return RedirectToAction(nameof(Index));
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Consent(bool accepted)
    {
        if (!accepted)
        {
            ModelState.AddModelError(string.Empty, "Please confirm that you understand this demo step.");
            return View();
        }
        var user = await users.GetUserAsync(User);
        if (user == null) return Challenge();
        user.BiometricDemoConsentAt = DateTime.UtcNow;
        await users.UpdateAsync(user);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet] public IActionResult ChangePassword() => View(new ChangePasswordViewModel());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var user = await users.GetUserAsync(User);
        if (user == null) return Challenge();
        var result = await users.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);
            return View(model);
        }
        user.MustChangePassword = false;
        user.OnboardingStatus = "InProgress";
        await users.UpdateAsync(user);
        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> IsSupplier(ApplicationUser user) =>
        user.UserType.Equals("Supplier", StringComparison.OrdinalIgnoreCase)
        || await users.IsInRoleAsync(user, "Supplier");

    private async Task<string> GetRoleLabel(ApplicationUser user)
    {
        var role = (await users.GetRolesAsync(user)).FirstOrDefault() ?? "Employee";
        return AdminController.RoleLabel(role);
    }

    private async Task MarkComplete(ApplicationUser user)
    {
        user.OnboardingStatus = "Completed";
        user.OnboardingCompletedAt = DateTime.UtcNow;
        await users.UpdateAsync(user);
    }
}
