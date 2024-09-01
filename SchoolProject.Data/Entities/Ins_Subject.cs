using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Ins_Subject
    {
        [Key]
        public int InsId { get; set; }
        [Key]
        public int SubID { get; set; }
        [ForeignKey("InsId")]
        [InverseProperty("Ins_Subject")]
        public Instructor? Instructor { get; set; }
        [ForeignKey("SubID")]
        [InverseProperty("Ins_Subject")]
        public Subject? Subject { get; set; }
    }
}
