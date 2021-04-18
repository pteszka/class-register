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

        public async Task DeleteTeacherAsync(Teacher teacher) 
        {   
            _context.Teachers.Remove(teacher);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Class>> GetClassesAsync()
        {
            var clss = await _context
                            .Classes
                            .ToListAsync();
            return clss;      
        }

        public async Task<Class> GetClassAsync(int id)
        {
            var clss = await _context
                            .Classes
                            .FirstOrDefaultAsync(c => c.ClassId == id);
            return clss;
        }

        public async Task CreateClassAsync(ClassDTO classDTO)
        {
            var clss = Class(classDTO);

            await _context
                    .Classes
                    .AddAsync(clss);
                    
            await _context
                    .SaveChangesAsync();        
        }

        public async Task DeleteClassAsync(Class clss)
        {
            _context.Classes.Remove(clss);

            await _context.SaveChangesAsync();        
        }     

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            var students = await _context
                                .Students
                                .ToListAsync();
            return students;
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            var student = await _context
                                .Students
                                .FirstOrDefaultAsync(s => s.StudentId == id);
            return student;
        }

        public async Task CreateStudentAsync(StudentDTO studentDTO)
        {
            var student = Student(studentDTO);

            await _context
                    .Students
                    .AddAsync(student);
                    
            await _context
                    .SaveChangesAsync();           }

        public async Task DeleteStudentAsync(Student student)
        {
            _context.Students.Remove(student);

            await _context.SaveChangesAsync();          
        }

        // Map TeacherDTO -> Teacher
        private Teacher Teacher(TeacherDTO teacherDTO) 
        {  
            return _mapper.Map<Teacher>(teacherDTO);
        }

        // Map ClassDTO -> Class
        private Class Class(ClassDTO classDTO) 
        {  
            return _mapper.Map<Class>(classDTO);
        }

        // Map StudentDTO -> Student
        private Student Student(StudentDTO studentDTO) 
        {  
            return _mapper.Map<Student>(studentDTO);
        }
    }
}
