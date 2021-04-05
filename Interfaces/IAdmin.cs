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
        Task AddTeacherAsync(Teacher teacher);
    }
}