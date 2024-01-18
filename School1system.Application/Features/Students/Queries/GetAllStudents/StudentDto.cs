using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolsystem.Application.Features.Students.Queries.GetAllStudents
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
    }
}
