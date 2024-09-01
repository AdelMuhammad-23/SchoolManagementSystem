using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Department : GeneralLocalizableEntitiy
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            Instructors = new HashSet<Instructor>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        [StringLength(500)]
        public string? DNameAr { get; set; }
        public int? InsManager { get; set; }

        [StringLength(500)]
        public string? DNameEn { get; set; }
        [InverseProperty(nameof(Student.Department))]
        public virtual ICollection<Student> Students { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Instructor> Instructors { get; set; }
        [ForeignKey("InsManager")]
        [InverseProperty("departmentManager")]

        public virtual Instructor? Instructor { get; set; }
    }

}
