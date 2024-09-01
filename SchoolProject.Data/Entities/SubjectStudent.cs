using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class SubjectStudent
    {

        [Key]
        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }
        public decimal? Grade { get; set; }

        [ForeignKey("StudID")]
        [InverseProperty("SubjectStudent")]
        public virtual Student? Student { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty("StudentsSubjects")]
        public virtual Subject? Subject { get; set; }
    }
}
