using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Subject
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<SubjectStudent>();
            DepartmetsSubjects = new HashSet<DepartmentSubject>();
            Ins_Subject = new HashSet<Ins_Subject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubID { get; set; }
        [StringLength(500)]
        public string? SubjectNameAR { get; set; }
        [StringLength(500)]
        public string? SubjectNameEn { get; set; }
        public DateTime Period { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<SubjectStudent> StudentsSubjects { get; set; }
        [InverseProperty("Subjects")]
        public virtual ICollection<DepartmentSubject> DepartmetsSubjects { get; set; }
        [InverseProperty("Subject")]
        public virtual ICollection<Ins_Subject> Ins_Subject { get; set; }
    }
}
