using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Controllers.Base;
using Schoolsystem.Application.Features.Students.Commands.StudentsCommand;
using Schoolsystem.Application.Features.Students.Queries.GetAllStudents;
using Schoolsystem.Application.Features.Students.Queries.GetStudentById;
using SchoolSystem.Domain.AppMetaData;
using static Schoolsystem.Application.Features.Students.Commands.StudentsCommand.AddStudentCommand;
using static Schoolsystem.Application.Features.Students.Commands.StudentsCommand.UpdateStudentCommand;


namespace SchoolAPI.Controllers
{
    
    [ApiController]
    public class StudentController : AppControllerBase
    {
       
        [HttpGet(Router.StudentRouting.GetAllStudents)]
        public async Task<ActionResult<List<StudentDto>>> GetAllStudent()
        {

            var dtos = await Mediator.Send(new GetStudentsListQuery());
            return Ok(dtos);
        }
        [HttpGet(Router.StudentRouting.GetByStudentId)]
        public async Task<ActionResult<StudentDTO>> GetStudentByID(int id)
        {

            var dtos = await Mediator.Send(new GetStudentByIdQuery() {StudentID=id });
            return Ok(dtos);
        }
        [HttpPost(Router.StudentRouting.AddStudent)]
        public async Task<IActionResult> AddStudents(AddStudentDto addStudentDto)
        {
            if(ModelState.IsValid)
            {
                var result = await Mediator.Send(new AddStudentCommand(addStudentDto));
                return NewResult(result);
            }
            return BadRequest();
         
        }
        [HttpPut(Router.StudentRouting.UpdateStudent)]
        public async Task<IActionResult> UpdateStudent( UStudentDto studentDto )
        {

            var result = await Mediator.Send( new UpdateStudentCommand(studentDto));
            return NewResult(result);
        }
        [HttpDelete(Router.StudentRouting.DeleteStudent)]
        public async Task<IActionResult> DeleteStudents(int id)
        {
            var deleteCommand = new DeleteStudentCommand() { StudentId = id };
            await Mediator.Send(deleteCommand);
            return NoContent();
        }

    }
}
