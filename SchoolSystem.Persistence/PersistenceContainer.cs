using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School1system.Application.Contracts;
using Schoolsystem.Application.Contracts;
using SchoolSystem.Persistence.Context;
using SchoolSystem.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
         

            services.AddScoped(typeof(ISchoolRepository<>), typeof(SchoolRepository<>));
            services.AddScoped(typeof(IEnrollmentRepository), typeof(EnrollmentRepository));

            return services;
        }
    }
}
