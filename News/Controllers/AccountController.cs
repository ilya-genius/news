using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using News.Data.Interfaces;
using News.Data.Models;
using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Localization;

namespace News.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAllAdmins _allAdmins;
        private readonly IHtmlLocalizer<AccountController> _localizer;
        public AccountController(IAllAdmins _allAdmins, IHtmlLocalizer<AccountController> localizer)
        {
            this._allAdmins = _allAdmins;
            _localizer = localizer;
        }

        private async Task Authenticate(Admin admin)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, admin.Email)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Admin admin = _allAdmins.Admins.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (admin != null)
                {
                    await Authenticate(admin);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", _localizer["Message"].Value);
            }
            return View(model);
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
