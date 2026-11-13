
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using returntask.Models;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace returntask.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public RegisterController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
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
        public async Task<IActionResult> Register(RegisterTDO Register)
        {
            var newUser = new IdentityUser
            {
                UserName = Register.Name,
                Email = Register.Email,
                PasswordHash = Register.Password
            };
            var result = await _userManager.CreateAsync(newUser, Register.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginTDO login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                if (result.IsLockedOut)
                    Console.WriteLine("User is locked out");

                if (result.IsNotAllowed)
                    Console.WriteLine("Login is not allowed");

                if (result.RequiresTwoFactor)
                    Console.WriteLine("Two factor required");
            }
            return View();
        }

    }
}
