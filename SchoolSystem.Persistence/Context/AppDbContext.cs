using Microsoft.EntityFrameworkCore;
using SchoolSystem.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                 .HasKey(x => new
                 {
                     x.Student_Id,
                     x.Course_ID
                 });

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Students)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.Student_Id)
                .IsRequired();

            modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Courses)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.Course_ID)
            .IsRequired();


            
        }
    }
}
