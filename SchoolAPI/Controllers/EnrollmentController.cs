using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Controllers.Base;
using Schoolsystem.Application.Features.EnrollmentF.Queries;
using SchoolSystem.Domain.AppMetaData;


namespace SchoolAPI.Controllers
{
   
    [ApiController]
    public class EnrollmentController : AppControllerBase
    {

        [HttpGet(Router.EnrollmentRouting.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await Mediator.Send(new GetAllStudentsAndCoursesQuery());
            return Ok(dtos);
        }


        [HttpGet(Router.EnrollmentRouting.GetByCourseId)]
        public async Task<IActionResult> GetAllStudentByCourseId(int id)
        {
            var dtos = await Mediator.Send(new GetAllStudentByCourseIdQuery() { courseIdQ=id});
            return Ok(dtos);
        }
        [HttpGet(Router.EnrollmentRouting.GetByStudentId)]
        public async Task<IActionResult> GetAllCoursesByStudentId(int id)
        {
            var dtos = await Mediator.Send(new GetAllCoursesByStudentIdQuery() { studentId = id });
            return Ok(dtos);
        }
    }
}
