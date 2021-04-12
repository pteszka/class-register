using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ClassRegister.Models;
using ClassRegister.ViewModels;

namespace ClassRegister.Interfaces 
{
    public interface IAdmin
    {
        Task<IEnumerable<Teacher>> GetTeachersAsync();
        Task<Teacher> GetTeacherAsync(int id);
        Task CreateTeacherAsync(TeacherDTO teacherDTO);
        Task DeleteTeacherAsync(Teacher teacher);

        // Task<IEnumerable<Teacher>> GetStudentsAsync();
        // Task<Teacher> GetStudentAsync(int id);
        // Task CreateStudentAsync(StudentDTO studentDTO);

    }
}