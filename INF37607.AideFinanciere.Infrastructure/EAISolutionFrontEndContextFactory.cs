using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EAISolutionFrontEnd.Infrastructure
{
    public class EAISolutionFrontEndContextContextFactory : IDesignTimeDbContextFactory<EAISolutionFrontEndContext>
    {
        public EAISolutionFrontEndContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EAISolutionFrontEndContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost, 1433;Initial Catalog=EAISolutionFrontEndDB;User ID=sa;Password=Pa55w0rd2021;integrated security=false;TrustServerCertificate=True;");

            return new EAISolutionFrontEndContext(optionsBuilder.Options);
        }
    }
}
