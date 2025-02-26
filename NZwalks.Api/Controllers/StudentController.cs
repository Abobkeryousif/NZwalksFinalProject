using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZwalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents() 
        {
            string[] StudentsName = new string[] {"Ali","bakry","ahmed","hassan","mosab" };
            return Ok(StudentsName);
        }
    }
}
