using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Domain.Entites
{
    public class Enrollment
    {
        public int Student_Id { get; set; }
        public int Course_ID { get; set; }
        public virtual Student Students { get; set; }
        public virtual Course Courses { get; set; }
        public Enrollment(int course_ID)
        {
            Course_ID = course_ID;
        }

    }
}
