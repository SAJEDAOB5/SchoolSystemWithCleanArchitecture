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
    public class DeleteStudentCommand:IRequest
    {
        public int StudentId { get; set; }


        public class DeleteStudentCommandHandler :  IRequestHandler<DeleteStudentCommand>
        {
            private readonly ISchoolRepository<Student> _schoolRepository;
            public DeleteStudentCommandHandler(ISchoolRepository<Student> schoolRepository)
            {
                _schoolRepository = schoolRepository;
            }


            async Task<Unit> IRequestHandler<DeleteStudentCommand, Unit>.Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
            {
                await _schoolRepository.DeleteAsync(request.StudentId);
                return Unit.Value;  
            }
        }
    }
}
