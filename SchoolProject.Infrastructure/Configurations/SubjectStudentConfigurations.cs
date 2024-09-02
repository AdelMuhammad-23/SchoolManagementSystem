using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    public class SubjectStudentConfigurations : IEntityTypeConfiguration<SubjectStudent>
    {
        public void Configure(EntityTypeBuilder<SubjectStudent> builder)
        {
            builder.HasKey(x => new { x.SubID, x.StudID });

            builder.HasOne(ds => ds.Student)
                       .WithMany(d => d.SubjectStudent)
                       .HasForeignKey(ds => ds.StudID);

            builder.HasOne(ds => ds.Subject)
                       .WithMany(s => s.StudentsSubjects)
                       .HasForeignKey(ds => ds.SubID);

        }
    }
}
