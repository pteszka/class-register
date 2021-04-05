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
    public class AdminController : Controller
    {
        private readonly IAccount _account;

        public AdminController(IAccount account)
        {
            _account = account;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

    }
}