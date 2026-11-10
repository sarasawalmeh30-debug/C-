using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Request_Management_System8.Models;

namespace Request_Management_System8.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly SignInManager<IdentityUser> _SignInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
      
        public async Task<IActionResult> Register(RegisterTDO Register)
        {
            if (!ModelState.IsValid)
            {
                return View(Register);
            }

            var obj = new IdentityUser
            {
                UserName = Register.Name,
                Email = Register.Email
            };

            var result = await _UserManager.CreateAsync(obj, Register.password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(Register);
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }

            await _UserManager.AddToRoleAsync(obj, "User");

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> Login(LoginTDO login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = await _UserManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email or password is incorrect.");
                return View(login);
            }

            var result = await _SignInManager.PasswordSignInAsync(
                user.UserName!,
                login.password,
                false,
                false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email or password is incorrect.");
            return View(login);
        }

        [HttpPost]
      
        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
