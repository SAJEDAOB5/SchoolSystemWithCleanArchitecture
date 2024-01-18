using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Domain.AppMetaData
{
    public static class Router
    {
        public const string Root = "Api";
        public const string Rule = Root + "/";

        public static class EnrollmentRouting
        {
            public const string prefix = Rule + "Enrollment";
            public const string GetAll = prefix + "/GetAllStudentAndCourses";
            public const string GetByCourseId = prefix + "/GetAllStudentByCourseId";
            public const string GetByStudentId = prefix + "/GetCoursesByStudentId";

        }

        public static class StudentRouting
        {
            public const string prefix = Rule + "Student";
            public const string GetAllStudents = prefix + "/GetAllStudents";
            public const string GetByStudentId = prefix + "/GetAllSTudentById";
            public const string AddStudent = prefix + "/AddStudent";
            public const string UpdateStudent = prefix + "/UpdateStudent";
            public const string DeleteStudent = prefix + "/DeleteStudent";

        }
        public static class CourseRouting
        {
            public const string prefix = Rule + "Course";
            public const string GetAllCourses = prefix + "/GetAllCourses";
            public const string GetByCourseId = prefix + "/GetAllSCourseById";
            public const string AddCourse = prefix + "/AddCourse";
            public const string UpdateCourse = prefix + "/UpdateCourse";
            public const string DeleteCourse = prefix + "/DeleteCourse";

        }

    }
}
