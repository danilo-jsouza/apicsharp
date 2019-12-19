using Infra.Data.Context;
using Infra.Data.Impl;
using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Extensions
{
    public static class DependencyInjectionRepository
    {
        public static void AddApplicationDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            services.AddDbContext<DbContext, ApplicationDbContext>(optionsAction, ServiceLifetime.Scoped);
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IFreelancerRepository, FreelancerRepository>();
            services.AddScoped<IHomeOfficeRepository, HomeOfficeRepository>();
            services.AddScoped<IPhysicalPersonRepository, PhysicalPersonRepository>();
        }
    }
}
