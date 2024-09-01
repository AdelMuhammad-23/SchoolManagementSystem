using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            InstructorsManage = new HashSet<Instructor>();
            Ins_Subject = new HashSet<Ins_Subject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? InsId { get; set; }
        public string? NameAR { get; set; }
        public string? NameEr { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public int DID { get; set; }

        #region relation instructor and department
        //one to many
        [ForeignKey(nameof(DID))]
        [InverseProperty("Instructors")]
        public Department Department { get; set; }
        //one to one
        [InverseProperty("Instructor")]
        public Department departmentManager { get; set; }
        #endregion

        #region relation instructor for himself
        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty("InstructorsManage")]
        public Instructor Supervisor { get; set; }
        [InverseProperty("Supervisor")]
        public virtual ICollection<Instructor> InstructorsManage { get; set; }
        #endregion

        #region  relation instructor and (Ins-Subject)
        //one to many
        [InverseProperty("Instructor")]
        public virtual ICollection<Ins_Subject> Ins_Subject { get; set; }
        #endregion

    }
}
