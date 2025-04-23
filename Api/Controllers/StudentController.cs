using DataAccess.EFCore.Mappers;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var student = await _unitOfWork.Students.GetAll();
                if (student == null) return StatusCode(400, "Danh sách Student trống");
                return Ok(student.Select(s => s.ToStudentDetailDto()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
    }
}
