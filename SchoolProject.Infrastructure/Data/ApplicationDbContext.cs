using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Identity;
using System.Reflection;

namespace SchoolProject.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // Models in DataBase
        public DbSet<User> Users { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<DepartmentSubject> departmentSubjects { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<SubjectStudent> subjectsStudents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }

}

