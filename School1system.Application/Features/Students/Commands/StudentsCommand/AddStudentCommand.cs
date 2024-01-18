using AutoMapper;
using MediatR;
using School1system.Application.Contracts;
using Schoolsystem.Application.Contracts;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Schoolsystem.Application.Features.Students.Commands.StudentsCommand.AddStudentCommand;

namespace Schoolsystem.Application.Features.Students.Commands.StudentsCommand
{
    public class AddStudentCommand:IRequest<Response<AddStudentDto>>
    {   
        private readonly AddStudentDto _addStudentDto;
        public AddStudentCommand(AddStudentDto addStudentDto)
        {
                _addStudentDto = addStudentDto;
               
        }

        public class AddStudentCommandHandler :ResponseHandler, IRequestHandler<AddStudentCommand,Response<AddStudentDto>>
        {
            #region Feilds and constructor

            private readonly ISchoolRepository<Student> _schoolRepository;
            private readonly IMapper _mapper;

            public AddStudentCommandHandler(ISchoolRepository<Student> schoolRepository, IMapper mapper)
            {
                _schoolRepository = schoolRepository;
                _mapper = mapper;
            }

           
            #endregion
                #region Handler
            public async Task<Response<AddStudentDto>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
            {


                var student = new Student
                    (
                     request._addStudentDto.StudentId,
                     request._addStudentDto.StudentName,
                     request._addStudentDto.StudentGPA,
                     request._addStudentDto.ListEnrollments.Select(a => new Enrollment(a.CourseId)).ToList())
                    ;

                await _schoolRepository.AddAsync(student);
                return Success( await Task.FromResult(request._addStudentDto));
            }
        }

      
        #endregion

        #region DTOs
        public class AddStudentDto
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public double StudentGPA { get; set; }
            public List<EnrollmentDto> ListEnrollments { get; set; } 

        }
        public class EnrollmentDto
        {
            public int CourseId { get; set; }
        }
        #endregion

    }
}
