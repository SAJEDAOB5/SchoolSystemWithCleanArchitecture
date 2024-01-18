using Microsoft.EntityFrameworkCore;
using Schoolsystem.Application.Contracts;
using SchoolSystem.Domain.Entites;
using SchoolSystem.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Persistence.Repositories
{
    public class EnrollmentRepository : SchoolRepository<Enrollment>, IEnrollmentRepository
    {
        public DbSet<Enrollment> _enrollments;
        public EnrollmentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _enrollments=dbContext.Set<Enrollment>();

        }

        public async Task<List<Enrollment>> GetAllCoursesByStudentId(int id)
        {
            var enrollmentsByStudentId = await _enrollments
                                           .Where(s=>s.Student_Id==id)
                                           .ToListAsync();

            return enrollmentsByStudentId;



        }

        public async Task<List<Enrollment>> GetAllStudentsAndCourses()
        {
            var studentAndAllCourses = await _enrollments.Include(s => s.Students)
                                                  .Include(s => s.Courses)
                                                  .ToListAsync();
            return studentAndAllCourses;
        }

        public async Task<List<Enrollment>> GetAllStudentsCourseId(int id)
        {
            var enrollmentsByCourseId = await _enrollments
                                            .Where(x => x.Course_ID == id)
                                            .ToListAsync();

            return enrollmentsByCourseId;
        }
    }
}
