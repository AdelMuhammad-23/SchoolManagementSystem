using SchoolProject.Data.Commons;

namespace SchoolProject.Data.Entities.Procedures
{
    public class DepartmentStudentCountProc : GeneralLocalizableEntitiy
    {
        public int DID { get; set; }
        public string? DNameAr { get; set; }
        public string? DNameEn { get; set; }
        public int StudentCount { get; set; }
    }
    public class DepartmentStudentCountProcParameter
    {
        public int DID { get; set; }
    }
}
