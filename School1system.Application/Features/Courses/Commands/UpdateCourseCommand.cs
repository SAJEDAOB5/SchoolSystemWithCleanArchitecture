using MediatR;
using School1system.Application.Contracts;
using Schoolsystem.Application.Contracts;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Schoolsystem.Application.Features.Courses.Commands.UpdateCourseCommand;

namespace Schoolsystem.Application.Features.Courses.Commands
{
    public class UpdateCourseCommand:IRequest<Response<UpdateCourseDto>>
    {
       
        private readonly UpdateCourseDto _courseDto;
        public UpdateCourseCommand(UpdateCourseDto courseDto)
        {

            _courseDto = courseDto;

        }


        #region
        public class UpdateCourseCommandHandler : ResponseHandler, IRequestHandler<UpdateCourseCommand, Response<UpdateCourseDto>>
        {
            private readonly ISchoolRepository<Course> _schoolRepository;
            public UpdateCourseCommandHandler(ISchoolRepository<Course> schoolRepository)
            {
                _schoolRepository = schoolRepository;
            }
            public async Task<Response<UpdateCourseDto>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
            {

                    var courses = _schoolRepository.Get()
                                             .Where(a => a.CourseId == request._courseDto.CourseId)
                                             .FirstOrDefault();
                    courses.Update(
                                   request._courseDto.Name,
                                   request._courseDto.InstructorName
                                  );
                    await _schoolRepository.UpdateAsync(courses);
                    return Success(await Task.FromResult(request._courseDto));
                
             

            }
        }
        #endregion
        #region
        public class UpdateCourseDto
        {
            public int CourseId { get; set; }
            public string Name { get; set; }
            public string InstructorName { get; set; }

        }
        #endregion
    }
}
