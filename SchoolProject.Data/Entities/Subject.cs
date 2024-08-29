using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class Subject
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<SubjectStudent>();
            DepartmetsSubjects = new HashSet<DepartmentSubject>();
        }
        [Key]
        public int SubID { get; set; }
        [StringLength(500)]
        public string SubjectNameAR { get; set; }
        [StringLength(500)]
        public string SubjectNameEn { get; set; }
        public DateTime Period { get; set; }
        public virtual ICollection<SubjectStudent> StudentsSubjects { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmetsSubjects { get; set; }
    }
}
