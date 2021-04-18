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

        public async Task<IActionResult> Classes()
        {
            return View(await _admin.GetClassesAsync());
        }

        public IActionResult CreateClass()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateClass([FromForm]ClassDTO classDTO)
        {
            if (ModelState.IsValid) 
            {   
                await _admin.CreateClassAsync(classDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(classDTO);
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteClass(int id) 
        {
            var cls = await _admin
                                .GetClassAsync(id);

            await _admin
                    .DeleteClassAsync(cls);

            return RedirectToAction(nameof(Index));
        }

    }
}