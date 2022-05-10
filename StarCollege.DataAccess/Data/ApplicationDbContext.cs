using Microsoft.EntityFrameworkCore;
using StarCollege.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarCollege.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        //Base Tables
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Student> Student { get; set; }

        //Merged Tables
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
    }
}
