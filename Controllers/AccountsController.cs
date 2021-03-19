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

namespace ClassRegister.Controllers
{
    public class ClassRegister : Controller
    {
        private readonly AccountServices _accountServices;

        public ClassRegister(AccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var account = await _accountServices.GetAccountFromDB(loginViewModel);

                if (account != null)
                {
                    var claimsIdentity = _accountServices.CreateClaim(account);
                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                    // add redirection to view 
                    return RedirectToAction("");
                }
                return NotFound();
            }
            return View(loginViewModel);
        }
    }
}