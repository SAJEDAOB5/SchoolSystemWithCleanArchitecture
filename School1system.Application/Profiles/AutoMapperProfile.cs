using AutoMapper;
using Schoolsystem.Application.Features.Students.Queries.GetAllStudents;
using Schoolsystem.Application.Features.Students.Queries.GetStudentById;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Schoolsystem.Application.Features.Courses.Queries.GetCourseById;
using static Schoolsystem.Application.Features.Students.Commands.StudentsCommand.AddStudentCommand;

namespace Schoolsystem.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
           


        }

    }
}
