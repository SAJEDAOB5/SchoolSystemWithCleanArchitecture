using School1system.Application.Contracts;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolsystem.Application.Contracts
{
    public interface IEnrollmentRepository : ISchoolRepository<Enrollment>
    {
        public Task<List<Enrollment>> GetAllStudentsAndCourses();
        public Task<List<Enrollment>> GetAllStudentsCourseId( int id);
        public Task<List<Enrollment>> GetAllCoursesByStudentId(int id);
    }
}
