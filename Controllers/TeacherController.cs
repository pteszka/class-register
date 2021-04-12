using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegister.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller 
    {

    }

}