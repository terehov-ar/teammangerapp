using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeamManageApp.Models;
using TeamManageApp.Services.HashPasswordService;
using TeamManageApp.ViewModels;

namespace TeamManageApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHashPasswordService _hashPasswordService;

        public AccountController(
            IHashPasswordService hashPasswordService)
        {
            _hashPasswordService = hashPasswordService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _hashPasswordService.Logging(model.Login, model.Password);
                if (user != null)
                {
                    await Authenticate(user.Login, user.Role); 

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login or password");
            }
            return View(model);
        }

        private async Task Authenticate(string login, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
    }
}
