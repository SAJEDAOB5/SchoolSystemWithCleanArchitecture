using MediatR;
using Schoolsystem.Application.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Schoolsystem.Application.Features.EnrollmentF.Queries.GetAllStudentByCourseIdQuery;

namespace Schoolsystem.Application.Features.EnrollmentF.Queries
{
    public class GetAllStudentByCourseIdQuery:IRequest<Response<List<CourseDto>>>
    {
        public int courseIdQ { get; set; }
        #region Handler
        public class GetAllStudentByCourseIdQueryHandler :ResponseHandler, IRequestHandler<GetAllStudentByCourseIdQuery, Response<List<CourseDto>>>
        {
            private readonly IEnrollmentRepository _enrollmentRepository;
            public GetAllStudentByCourseIdQueryHandler(IEnrollmentRepository enrollmentRepository)
            {
                _enrollmentRepository = enrollmentRepository;
            }
            public async Task<Response<List<CourseDto>>> Handle(GetAllStudentByCourseIdQuery request, CancellationToken cancellationToken)
            {
                var enrollmnts = await _enrollmentRepository.GetAllStudentsCourseId(request.courseIdQ);
                var result=enrollmnts.Distinct().Select(c=> new CourseDto
                {
                    CourseName = c.Courses.Name,
                    InstructorName = c.Courses.InstructorName,
                    ListEnrollments=enrollmnts.Select(s=> new erollmentCourseDto
                                               { 
                                                 studentName=s.Students.Name
                                               }).ToList()
                }).ToList();
                return Success(result);  
            }
                    
            
         }
        #endregion
        #region Dto
        public class CourseDto
        {
            public string CourseName { get; set; }
            public string InstructorName { get; set; }
            public ICollection<erollmentCourseDto> ListEnrollments { get; set; } = new List<erollmentCourseDto>();
        }
        public class erollmentCourseDto
        {
            public string studentName { get; set; }
        }
        #endregion
    }
}

