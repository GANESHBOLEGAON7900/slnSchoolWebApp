using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Models.Entities;
using System;

namespace SchoolWebApp.Data
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        DbSet<Student> students { get; set; }
        DbSet<Instructor> instructors { get; set; }
            
        DbSet<Course>courses { get; set; }
        DbSet<EnrollCourse> EnrolledCourse{ get; set; }

        DbSet<Grades> Grades { get; set; }

    }
}
