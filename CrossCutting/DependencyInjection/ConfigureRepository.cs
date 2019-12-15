using Infra.Data.Context;
using Infra.Data.Impl;
using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void AddApplicationDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            services.AddDbContext<DbContext, ApplicationDbContext>(optionsAction, ServiceLifetime.Scoped);
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
