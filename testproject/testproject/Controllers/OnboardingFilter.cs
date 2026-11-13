
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Identity;
using testproject.Models;

public class OnboardingFilter : IAsyncActionFilter
{
    private readonly UserManager<ApplicationUser> _userManager;

    public OnboardingFilter(
        UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        var controller = context.RouteData.Values["controller"]?.ToString();

        if (controller == "Account" ||
            controller == "Onboarding")
        {
            await next();
            return;
        }

        if (context.HttpContext.User.Identity?.IsAuthenticated != true)
        {
            await next();
            return;
        }

        var user = await _userManager.GetUserAsync(
            context.HttpContext.User);

        if (user == null)
        {
            context.Result = new ForbidResult();
            return;
        }

        if (!user.IsActive)
        {
            context.Result = new ForbidResult();
            return;
        }

        if (user.MustChangePassword ||
            user.OnboardingStatus != "Completed")
        {
            context.Result = new RedirectToActionResult(
                "Index",
                "Onboarding",
                null
            );

            return;
        }

        await next();
    }
}
