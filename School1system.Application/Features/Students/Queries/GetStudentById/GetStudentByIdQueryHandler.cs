using AutoMapper;
using MediatR;
using School1system.Application.Contracts;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolsystem.Application.Features.Students.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDTO>
    {
        private readonly ISchoolRepository<Student> _schoolRepository;
        private readonly IMapper _mapper;

        public GetStudentByIdQueryHandler(ISchoolRepository<Student> schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }
        public async Task<StudentDTO> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var students = await _schoolRepository.GetByIdAsync(request.StudentID);
            return _mapper.Map<StudentDTO>(students);
        }
    }
}
