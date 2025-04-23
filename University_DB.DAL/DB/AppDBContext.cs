using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni.DAL.Entity;

namespace Uni.DAL.DB
{
    public class AppDBContext : DbContext
    {
            public AppDBContext(DbContextOptions<AppDBContext> options)
                : base(options)
            {
            }

            public DbSet<Student> Students { get; set; }
            public DbSet<Profile> Profiles { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Records> Records { get; set; }
            public DbSet<Takes> Takes { get; set; }
            public DbSet<Instructor> Instructors { get; set; }
            public DbSet<Teaches> Teaches { get; set; }
            public DbSet<Department> Departments { get; set; }
            public DbSet<AcademicStatus> AcademicStatus { get; set; }
        }
}
