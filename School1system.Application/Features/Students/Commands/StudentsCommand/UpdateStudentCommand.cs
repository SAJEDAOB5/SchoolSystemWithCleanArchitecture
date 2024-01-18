using MediatR;
using School1system.Application.Contracts;
using Schoolsystem.Application.Contracts;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Schoolsystem.Application.Features.Students.Commands.StudentsCommand.UpdateStudentCommand;

namespace Schoolsystem.Application.Features.Students.Commands.StudentsCommand
{
    public class UpdateStudentCommand: IRequest<Response<UStudentDto>>
    {  private readonly UStudentDto _StudentDto;
    public UpdateStudentCommand(UStudentDto studentDto)
    {
            _StudentDto = studentDto;

    }

        public class UpdateStudentCommandHandler : ResponseHandler, IRequestHandler<UpdateStudentCommand, Response<UStudentDto>>
        {
            private readonly ISchoolRepository<Student> _schoolRepository;
            public UpdateStudentCommandHandler(ISchoolRepository<Student> schoolRepository)
            {
                    _schoolRepository = schoolRepository;
            }
            public async Task<Response<UStudentDto>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
            {

                var student = _schoolRepository.Get()
                                               .Where(a => a.StudentId == request._StudentDto.StudentId)
                                               .FirstOrDefault();
                student.Update(
                                request._StudentDto.StudentName,
                                request._StudentDto.StudentGPA
                              );
                await _schoolRepository.UpdateAsync( student );
                return Success(await Task.FromResult(request._StudentDto));
            } 
        }
        public class UStudentDto
        {
            public int StudentId { get;  set; }
            public string StudentName { get; set; }
            public double StudentGPA { get; set; } 
        }
    }
}
