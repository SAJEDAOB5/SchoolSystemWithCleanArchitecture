using AutoMapper;
using MediatR;
using School1system.Application.Contracts;
using Schoolsystem.Application.Contracts;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolsystem.Application.Features.Students.Queries.GetAllStudents
{
    public class GetStudentsHandler :IRequestHandler<GetStudentsListQuery,List<StudentDto>>
    {
        private readonly ISchoolRepository<Student> _schoolRepository;
        private readonly IMapper _mapper;

        public GetStudentsHandler(ISchoolRepository<Student> schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }
        public async Task<List<StudentDto>> Handle(GetStudentsListQuery request, CancellationToken cancellationToken)
        {
            var students = await _schoolRepository.GetAllAsync();
            return _mapper.Map<List<StudentDto>>(students);
        }
    }
}
