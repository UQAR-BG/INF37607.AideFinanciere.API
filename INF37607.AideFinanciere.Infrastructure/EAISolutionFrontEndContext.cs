using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using EAISolutionFrontEnd.Core;

namespace EAISolutionFrontEnd.Infrastructure
{
    public class EAISolutionFrontEndContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<User> Users { get; set; }
        public EAISolutionFrontEndContext(DbContextOptions options) : base(options) { }

    }

}
