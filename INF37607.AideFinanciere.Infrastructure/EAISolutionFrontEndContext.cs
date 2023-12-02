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
        public DbSet<FinancialAide> FinancialAide { get; set; }
        public EAISolutionFrontEndContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<Request>()
                .HasOne(r => r.User)
                .WithMany(u => u.Requests);
            modelBuilder.Entity<Request>()
                .HasOne(r => r.FinancialAid)
                .WithOne();
            
            modelBuilder.Entity<User>()
                .HasKey(r => r.Id);
            
            modelBuilder.Entity<FinancialAide>()
                .HasKey(r => r.Id);
        }
    }

}
