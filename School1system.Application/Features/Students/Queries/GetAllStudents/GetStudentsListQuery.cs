using MediatR;
using Schoolsystem.Application.Contracts;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolsystem.Application.Features.Students.Queries.GetAllStudents
{
    public class GetStudentsListQuery:IRequest<List<StudentDto>>
    {
    }
}
