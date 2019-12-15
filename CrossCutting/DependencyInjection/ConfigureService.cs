using Microsoft.Extensions.DependencyInjection;
using Services.Impl;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IFreelancerService, FreelancerService>();
            services.AddScoped<IHomeOfficeService, HomeOfficeService>();
        }
    }
}
