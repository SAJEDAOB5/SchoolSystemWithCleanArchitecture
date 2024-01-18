using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Domain.Entites
{
    public class Student
    {
        public int StudentId { get; private set; }
        public string Name { get; private set; }
        public double GPA { get; private set; }
        public virtual ICollection<Enrollment> Enrollments { get; private set; }

        public Student()
        {

        }
        public Student(int _StudentId, string _Name, double _Gpa, ICollection<Enrollment> enrollments)

        {
            StudentId = _StudentId;
            Name = _Name;
            GPA = _Gpa;
            Enrollments = enrollments;

        }

        public Student( string _Name, double _Gpa)

        {
          
            Name = _Name;
            GPA = _Gpa;
          

        }
        public void Update( string _Name, double _Gpa)
        {
            Name = _Name;
            GPA = _Gpa;
        }
    }
}
