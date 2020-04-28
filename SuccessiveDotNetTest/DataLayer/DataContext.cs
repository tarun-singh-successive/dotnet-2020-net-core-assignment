using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataLayer
{
    public class DataContext : DbContext
    {
        private string _connectionString;

        public DataContext()
        {
        }

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
            builder.Entity<Candidates>(d =>
            {
                d.ToTable("Candidates");
                d.HasKey(id => id.Id);
                d.HasIndex(e => e.Email).IsUnique();
            });
            builder.Entity<InterviewSchedules>()
            .HasOne<Candidates>(s => s.candidates)
            .WithMany(e => e.InterviewSchedules)
            .HasForeignKey(fk => fk.CandidateId);


        }
    }
}
