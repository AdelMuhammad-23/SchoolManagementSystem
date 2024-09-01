using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // Models in DataBase
        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<DepartmentSubject> departmentSubjects { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<SubjectStudent> subjectsStudents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentSubject>()
                .HasKey(x => new { x.SubID, x.DID });
            modelBuilder.Entity<Ins_Subject>()
                .HasKey(x => new { x.SubID, x.InsId });
            modelBuilder.Entity<SubjectStudent>()
              .HasKey(x => new { x.SubID, x.StudID });

            modelBuilder.Entity<Instructor>()
              .HasOne(x => x.Supervisor)
              .WithMany(x => x.InstructorsManage)
              .HasForeignKey(x => x.SupervisorId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
              .HasOne(x => x.Instructor)
              .WithOne(x => x.departmentManager)
              .HasForeignKey<Department>(x => x.InsManager)
              .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Department>()
            //        .HasIndex(d => d.InsManager)
            //        .IsUnique();

            //base.OnModelCreating(modelBuilder);
        }

    }

}

