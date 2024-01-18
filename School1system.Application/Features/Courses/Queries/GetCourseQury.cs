using MediatR;
using School1system.Application.Contracts;
using Schoolsystem.Application.Contracts;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Schoolsystem.Application.Features.Courses.Queries.GetCourseQury;

namespace Schoolsystem.Application.Features.Courses.Queries
{
    public class GetCourseQury:IRequest<Response<List<CourseDto>>>
    {
        #region Handler
        public class GetCourseQuryHandler : ResponseHandler, IRequestHandler<GetCourseQury, Response<List<CourseDto>>>
        {
            private readonly ISchoolRepository<Course> _schoolRepository;
            public GetCourseQuryHandler(ISchoolRepository<Course> schoolRepository)
            {
                    _schoolRepository = schoolRepository;
            }
            public async Task<Response<List<CourseDto>>> Handle(GetCourseQury request, CancellationToken cancellationToken)
            {
                var corses =await _schoolRepository.GetAllAsync();
                var Allcorses=corses.Select(c => new CourseDto
                {
                    CourseId = c.CourseId,
                    Name = c.Name,
                    InstructorName = c.InstructorName
                }).ToList();
                return Success(Allcorses);
            }
        }
        #endregion


        #region
        public class CourseDto
        {
            public int CourseId { get;  set; }
            public string Name { get;  set; }
            public string InstructorName { get;  set; }

        }
       
        #endregion
    }
}
