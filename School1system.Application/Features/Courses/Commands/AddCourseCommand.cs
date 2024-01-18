using MediatR;
using School1system.Application.Contracts;
using Schoolsystem.Application.Contracts;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Schoolsystem.Application.Features.Courses.Commands.AddCourseCommand;

namespace Schoolsystem.Application.Features.Courses.Commands
{
    public class AddCourseCommand:IRequest<Response<AddCourseDto>>
    {
        private readonly AddCourseDto _courseDto;
        public AddCourseCommand(AddCourseDto courseDto)
        {
            _courseDto = courseDto;
        }
        public class AddCourseCommandHandler : ResponseHandler, IRequestHandler<AddCourseCommand, Response<AddCourseDto>>
        {
            private readonly ISchoolRepository<Course> _schoolRepository; 
            public AddCourseCommandHandler(ISchoolRepository<Course> schoolRepository)
            {
                _schoolRepository = schoolRepository;
            }
            public async Task<Response<AddCourseDto>> Handle(AddCourseCommand request, CancellationToken cancellationToken)
            {
                var courses = new Course
                    (
                      request._courseDto.CourseId,
                      request._courseDto.Name,
                      request._courseDto.InstructorName
                    );
                await _schoolRepository.UpdateAsync( courses );
                return Success(await Task.FromResult(request._courseDto));
            }
        }

        #region
        public class AddCourseDto
        {
            public int CourseId { get; set; }
            public string Name { get; set; }
            public string InstructorName { get; set; }

        }
        #endregion

    }
}
