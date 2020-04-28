using Microsoft.EntityFrameworkCore;
using Schedule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule
{
    public class DataContext:DbContext
    {
        private string _connectionString;
        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<InterviewSchedule> InterviewSchedule { get; set; }
       


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(_connectionString);

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Candidate>(data =>
            {
                data.ToTable("Candidates");

                data.HasKey(prime => prime.Id);  //Id attribute of Candidate class as a primary key
               

            });
            modelBuilder.Entity<InterviewSchedule>(data => data.HasKey(prime => prime.Id));

            modelBuilder.Entity<InterviewSchedule>()   //here declared CandidateID as a ForeignKey 
                                                      // for eatablishing one to many realtion
                .HasOne<Candidate>(dept => dept.candidates)
                .WithMany(relation => relation.InterviewData)
                .HasForeignKey(key => key.CandidateId);

           
           
        }




    }
}
