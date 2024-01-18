using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Controllers.Base;
using Schoolsystem.Application.Features.Courses.Commands;
using Schoolsystem.Application.Features.Courses.Queries;
using SchoolSystem.Domain.AppMetaData;
using static Schoolsystem.Application.Features.Courses.Commands.AddCourseCommand;
using static Schoolsystem.Application.Features.Courses.Commands.UpdateCourseCommand;
using static Schoolsystem.Application.Features.Courses.Queries.GetCourseById;

namespace SchoolAPI.Controllers
{
    [ApiController]
    public class CourseController : AppControllerBase
    {
        [HttpGet(Router.CourseRouting.GetAllCourses)]
        public async Task<IActionResult> GetCourses()
        {
            var dtos = await Mediator.Send(new GetCourseQury());
            return Ok(dtos);
        }
        [HttpGet(Router.CourseRouting.GetByCourseId)]
        public async Task<ActionResult<CourseDto>> GetCourseByID(int id)
        {

            var dtos = await Mediator.Send(new GetCourseById() { CourseId = id });
            return Ok(dtos);
        }
        [HttpPost(Router.CourseRouting.AddCourse)]
        public async Task<IActionResult> AddCourse(AddCourseDto addCourseDto)
        {
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(new AddCourseCommand(addCourseDto));
                return NewResult(result);
            }
            return BadRequest();

        }

        [HttpPut(Router.CourseRouting.UpdateCourse)]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto  courseDto)
        {

            var result = await Mediator.Send(new UpdateCourseCommand(courseDto));
            return NewResult(result);
        }
        [HttpDelete(Router.CourseRouting.DeleteCourse)]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var deleteCommand = new DeleteCourseCommand() { Id = id };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }
    }
}
