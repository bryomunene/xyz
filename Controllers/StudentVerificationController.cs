using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using xyz.Data;
using xyz.Models;

namespace xyz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentVerificationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentVerificationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("verify")]
        public async Task<ActionResult<StudentVerificationResponse>> VerifyStudent([FromBody] StudentVerificationRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.StudentId))
            {
                return BadRequest("Invalid request.");
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.StudentId == request.StudentId
                                           && s.FirstName == request.FirstName
                                           && s.LastName == request.LastName);

            if (student == null)
            {
                return NotFound(new StudentVerificationResponse
                {
                    StudentId = request.StudentId,
                    IsEnrolled = false,
                    Message = "Student not found."
                });
            }

            return Ok(new StudentVerificationResponse
            {
                StudentId = student.StudentId,
                IsEnrolled = student.IsEnrolled,
                Message = "Student found."
            });
        }
    }
}
