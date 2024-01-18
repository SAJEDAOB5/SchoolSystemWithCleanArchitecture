using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolsystem.Application.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQuery:IRequest<StudentDTO>
    {
        public int StudentID { get; set; }
    }
}
