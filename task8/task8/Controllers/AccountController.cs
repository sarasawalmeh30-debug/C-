using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using task8.Models;

namespace task8.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            if (ModelState.IsValid)
            {
                var newUser = new IdentityUser
                {
                    UserName = register.Username,
                    Email = register.Email
                };

                var result = await _userManager.CreateAsync(newUser, register.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "User");
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            return View(register);
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Account is locked out");
            }
            else if (result.IsNotAllowed)
            {
                ModelState.AddModelError("", "Login is not allowed");
            }
            else if (result.RequiresTwoFactor)
            {
                ModelState.AddModelError("", "Two factor authentication is required");
            }
            else
            {
                ModelState.AddModelError("", "Incorrect password");
            }

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
