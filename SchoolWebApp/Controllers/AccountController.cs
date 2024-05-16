using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApp.Models.Entities;
using SchoolWebApp.Models.ViewModel;
using System.Data;
using System.Security.Claims;

namespace SchoolWebApp.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Login";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);
                if (result.Succeeded)
                {

                    var role = User.FindFirst(ClaimTypes.Role);
                    if (role.Value == "Admin")
                        return RedirectToActionPermanent("Index", "Admin");

                    return RedirectToActionPermanent("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }
        [HttpGet]

        public IActionResult Registration()
        {
            ViewBag.Title = "Registration";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email, //$"{model.FirstName.ToLower()}_{model.LastName.ToLower()}",
                    Password = model.Password
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return RedirectToActionPermanent("Login", "Account");

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToActionPermanent("Login", "Account");
        }

    }
}
