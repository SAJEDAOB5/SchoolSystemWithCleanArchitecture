using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolSystem.Domain.Entites
{
    public class Course
    {
        public int CourseId { get; private set; }
        public string Name { get; private set; }
        public string InstructorName { get; private set; }
        public virtual ICollection<Enrollment> Enrollments { get; private set; }

        public Course()
        {
                
        }
        public Course(int courseId, string name, string instructorName)
        {
            CourseId = courseId;
            Name = name;
            InstructorName = instructorName;
        }

        public void Update(string name, string instructorName)
        {
            Name = name;
            InstructorName = instructorName;
        }
    }
}
