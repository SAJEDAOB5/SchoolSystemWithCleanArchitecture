using MediatR;
using School1system.Application.Contracts;
using Schoolsystem.Application.Contracts;
using SchoolSystem.Domain.Entites;


namespace Schoolsystem.Application.Features.Courses.Commands
{
    public class DeleteCourseCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteCourseCommandHandler : ResponseHandler, IRequestHandler<DeleteCourseCommand>
        {
            private readonly ISchoolRepository<Student> _schoolRepository;
            public DeleteCourseCommandHandler(ISchoolRepository<Student> schoolRepository)
            {
                _schoolRepository = schoolRepository;
            }

            public async Task<Response<string>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
            {
               
                return Deleted<string>();
            }

             async Task<Unit> IRequestHandler<DeleteCourseCommand, Unit>.Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
            {
                await _schoolRepository.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }
    }
}

