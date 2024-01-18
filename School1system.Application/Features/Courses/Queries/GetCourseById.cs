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
using static Schoolsystem.Application.Features.Courses.Queries.GetCourseById;

namespace Schoolsystem.Application.Features.Courses.Queries
{
    public class GetCourseById:IRequest<CourseDto>
    {   public int CourseId {  get; set; }
        public class GetCourseByIdHandler : ResponseHandler, IRequestHandler<GetCourseById, CourseDto>
        {
            private readonly ISchoolRepository<Course> _schoolRepository;
            private readonly IMapper _mapper;
            public GetCourseByIdHandler(ISchoolRepository<Course> schoolRepository, IMapper mapper)
            {
                _schoolRepository = schoolRepository;
                _mapper = mapper;
            }

            public async Task<CourseDto> Handle(GetCourseById request, CancellationToken cancellationToken)
            {
                var courses= await _schoolRepository.GetByIdAsync(request.CourseId);
                return _mapper.Map<CourseDto>(courses);
            }
        }
            #region
            public class CourseDto
        {
            public int CourseId { get; set; }
            public string Name { get; set; }
            public string InstructorName { get; set; }

        }

        #endregion
    }
}
