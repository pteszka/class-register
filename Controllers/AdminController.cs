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
using ClassRegister.Models;

namespace ClassRegister.Controllers
{   
    // [ViewLayout("_AdminLayout")]
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

        public IActionResult CreateTeacher()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeacher([FromForm]TeacherDTO teacherDTO)
        {
            if (ModelState.IsValid) 
            {   
                await _admin.CreateTeacherAsync(teacherDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(teacherDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTeacher(int id) 
        {
            var teacher = await _admin
                                .GetTeacherAsync(id);

            await _admin
                    .DeleteTeacherAsync(teacher);

            return RedirectToAction(nameof(Index));
        }

    }
}