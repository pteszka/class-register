using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClassRegister.Data;
using ClassRegister.Models;
using ClassRegister.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ClassRegister.Interfaces;

namespace ClassRegister.Services
{
    public class AdminServices : IAdmin
    {
        private readonly ClassRegisterContext _context;

        public AdminServices(ClassRegisterContext context)
        {
            _context = context;
        }

        public async Task AddTeacherAsync(Teacher teacher)
        {
            await _context
                .AddAsync(teacher);
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            var teachers = await _context
                                .Teachers
                                .ToListAsync();
            return teachers;
        }

        public async Task<Teacher> GetTeacherAsync(int id)
        {
            var teacher = await _context
                                .Teachers
                                .FirstOrDefaultAsync(t => t.TeacherId == id);
            
            // if (teacher == null)
            // {
            //     throw new ArgumentNullException(nameof(teacher));
            // }
            return teacher;
        }
    }
}
