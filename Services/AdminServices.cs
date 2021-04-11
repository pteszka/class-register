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
using ClassRegister.Profiles;
using AutoMapper;

namespace ClassRegister.Services
{
    public class AdminServices : IAdmin
    {
        private readonly ClassRegisterContext _context;
        private readonly IMapper _mapper;

        public AdminServices(ClassRegisterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // public async Task CreatePersonalInfoAsync(TeacherDTO teacherDTO)
        // {   
        //     var personalInfo = PersonalInfo(teacherDTO);
        //     await _context.AddAsync(personalInfo);
        //     await _context.SaveChangesAsync();               
        // }
        // public async Task CreateAccountAsync(TeacherDTO teacherDTO)
        // {   
        //     var account = Account(teacherDTO);
        //     await _context.AddAsync(account);
        //     await _context.SaveChangesAsync();
        // }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            var teachers = await _context
                                .Teachers
                                .Include(t => t.PersonalInfo)
                                .Include(t => t.Account)
                                .ToListAsync();
            return teachers;
        }

        public async Task<Teacher> GetTeacherAsync(int id)
        {
            var teacher = await _context
                                .Teachers
                                .FirstOrDefaultAsync(t => t.TeacherId == id);
            return teacher;
        }

        public async Task CreateTeacherAsync(TeacherDTO teacherDTO) 
        {
            var teacher = Teacher(teacherDTO);

            await _context
                    .Teachers
                    .AddAsync(teacher);
                    
            await _context
                    .SaveChangesAsync();
        }

        // Map TeacherDTO -> Account
        private Account Account(TeacherDTO teacherDTO) 
        {  
            return _mapper.Map<Account>(teacherDTO);
        }
        
        // Map TeacherDTO -> PersonalInfo
        private PersonalInfo PersonalInfo(TeacherDTO teacherDTO) 
        {  
            return _mapper.Map<PersonalInfo>(teacherDTO);
        }        

        // Map TeacherDTO -> Teacher
        private Teacher Teacher(TeacherDTO teacherDTO) 
        {  
            return _mapper.Map<Teacher>(teacherDTO);
        }
    }
}
