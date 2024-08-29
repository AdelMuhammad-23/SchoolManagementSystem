using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Student : GeneralLocalizableEntitiy
    {
        [Key]
        public int StudID { get; set; }
        [StringLength(200)]
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
        public int? DID { get; set; }

        [ForeignKey("DID")]
        public virtual Department Department { get; set; }
    }
}
