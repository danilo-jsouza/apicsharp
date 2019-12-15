using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            string connectionString = GetConnectionString();
            builder.UseMySql(connectionString);
            return new ApplicationDbContext(builder.Options);
        }

        public static string GetConnectionString()
        {
            return "";
        }
    }
}
