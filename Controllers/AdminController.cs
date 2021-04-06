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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdmin _admin;

        public AdminController(IAdmin admin)
        {
            _admin = admin;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _admin.GetTeachersAsync());
        }
    }
}