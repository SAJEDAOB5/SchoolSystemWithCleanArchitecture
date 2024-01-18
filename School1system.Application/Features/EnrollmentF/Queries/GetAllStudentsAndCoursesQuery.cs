using MediatR;
using School1system.Application.Contracts;
using Schoolsystem.Application.Contracts;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Schoolsystem.Application.Features.EnrollmentF.Queries.GetAllStudentsAndCoursesQuery;

namespace Schoolsystem.Application.Features.EnrollmentF.Queries
{
    public class GetAllStudentsAndCoursesQuery : IRequest<Response<List<StudentEnrollmentDto>>>
    {

        #region Handler
        public class GetAllStudentsAndCoursesQueryHandler :ResponseHandler, IRequestHandler<GetAllStudentsAndCoursesQuery, Response<List<StudentEnrollmentDto>>>
        {   private readonly IEnrollmentRepository _enrollmentRepository;
            public GetAllStudentsAndCoursesQueryHandler(IEnrollmentRepository enrollmentRepository)
            {
                _enrollmentRepository = enrollmentRepository;   
            }
            public async Task<Response<List<StudentEnrollmentDto>>> Handle(GetAllStudentsAndCoursesQuery request, CancellationToken cancellationToken)
            {
                var Query = await _enrollmentRepository.GetAllStudentsAndCourses();
                var result = Query
                                 .Select(s => new StudentEnrollmentDto
                                 {
                                     StudentId = s.Students.StudentId,
                                     StudentName = s.Students.Name,
                                     Gpa = s.Students.GPA,
                                     Enrollments = Query.Select(e => new EnrollmentDtoQ
                                     {
                                         CourseId = e.Courses.CourseId,
                                         CourseName = e.Courses.Name,
                                         CourseInstructorName = e.Courses.InstructorName
                                     }).ToList()
                                 })
                                 .ToList();

                return Success(result);
            }
        }
        #endregion

        #region DTO
        public class StudentEnrollmentDto
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public double Gpa { get; set; }
            public ICollection<EnrollmentDtoQ> Enrollments { get; set; } =new List<EnrollmentDtoQ>();

        }
        public class EnrollmentDtoQ
        {
            public int CourseId { get; set; }
            public string CourseName { get; set; }
            public string CourseInstructorName { get; set; }          
        }
        #endregion
    }
}
