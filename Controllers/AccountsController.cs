using ClassRegister.Data;
using ClassRegister.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ClassRegister.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;
using ClassRegister.Interfaces;

namespace ClassRegister.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccount _account;

        public AccountsController(IAccount account)
        {
            _account = account;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var account = await _account.GetAccountFromDB(loginViewModel);

                if (account != null)
                {
                    var claimsIdentity = _account.CreateClaim(account);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                    // add redirection to view 
                    return View();
                }
                return NotFound();
            }
            return View(loginViewModel);
        }
    }
}