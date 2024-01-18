using MediatR;
using School1system.Application.Contracts;
using Schoolsystem.Application.Contracts;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Schoolsystem.Application.Features.EnrollmentF.Queries.GetAllCoursesByStudentIdQuery;

namespace Schoolsystem.Application.Features.EnrollmentF.Queries
{
    public class GetAllCoursesByStudentIdQuery:IRequest<Response<List<StudentEnrollmentDto>>>
    {
        public int studentId { get; set; }
        #region Handler
        public class GetAllCoursesByStudentIdQueryHandler :ResponseHandler, IRequestHandler<GetAllCoursesByStudentIdQuery, Response<List<StudentEnrollmentDto>>>
        {
            readonly private IEnrollmentRepository _enrollmentRepository;
            public GetAllCoursesByStudentIdQueryHandler(IEnrollmentRepository enrollmentRepository)
            {
                _enrollmentRepository = enrollmentRepository;  
            }
            public async Task<Response<List<StudentEnrollmentDto>>> Handle(GetAllCoursesByStudentIdQuery request, CancellationToken cancellationToken)
            {
                var enrollments = await _enrollmentRepository.GetAllCoursesByStudentId(request.studentId);
                var result = enrollments
                        .Select(x => new StudentEnrollmentDto()
                        {
                            StudentName = x.Students.Name,
                            SrudentGPA = x.Students.GPA,
                            EnrollmentsList = enrollments
                            .Where(x => x.Students.StudentId == request.studentId)
                            .Select(e => new EnrollmentDto()
                            {
                                CourseName = e.Courses.Name
                            }).ToList()
                        }).ToList();
                return Success(result);


            }
        }
        #endregion

        #region Dto
        public class StudentEnrollmentDto
        {
            public string StudentName { get; set; }
            public double SrudentGPA { get; set; }
           
            public ICollection<EnrollmentDto> EnrollmentsList { get; set; } = new List<EnrollmentDto>();
        }

        public class EnrollmentDto
        {
            public string CourseName { get; set; }


        }
        #endregion
    }
}
