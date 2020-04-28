using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public virtual DbSet<Candidates> Candidates { get; set; }
        public virtual DbSet<InterviewSchedules> InterviewSchedules { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(_connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Candidates>(e =>
            {
                e.ToTable("Candidates");
                e.HasKey(x => x.Id);
                e.HasIndex(x => x.Email).IsUnique();
            });
            base.OnModelCreating(builder);

            builder.Entity<InterviewSchedules>(d =>
            {
                d.ToTable("InterviewSchedules");
                d.HasKey(x => x.Id);
            });

        }

    }
}
