using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Configurations
{
    public class Ins_SubjectConfigurations : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.InsId });

            builder.HasOne(ds => ds.Instructor)
                       .WithMany(d => d.Ins_Subject)
                       .HasForeignKey(ds => ds.InsId);

            builder.HasOne(ds => ds.Subject)
                       .WithMany(s => s.Ins_Subject)
                       .HasForeignKey(ds => ds.SubID);

        }
    }
}
