using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class Department : GeneralLocalizableEntitiy
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
        }
        [Key]
        public int DID { get; set; }
        [StringLength(500)]
        public string DNameAr { get; set; }
        [StringLength(500)]
        public string DNameEn { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
    }

}
