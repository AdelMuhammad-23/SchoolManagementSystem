namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string Root = "Api/";
        public const string Version = "V1/";
        public const string Rule = Root + Version;

        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student/";
            public const string List = Prefix + "List";
            public const string GetById = Prefix + "{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "{id}";
            public const string Paginated = Prefix + "Paginated";

        }
        public static class SubjectRouting
        {
            public const string Prefix = Rule + "Subject/";
            public const string GetSubjectList = Prefix + "GetSubjectList";
            public const string GetSubjectById = Prefix + "GetSubjectById/{id}";
            public const string AddSubject = Prefix + "AddSubject";
            public const string EditSubject = Prefix + "EditSubject";
            public const string DeleteSubject = Prefix + "DeleteSubject/{id}";
            public const string Paginated = Prefix + "Paginated";

        }
        public static class EmailRouting
        {
            public const string Prefix = Rule + "EmailRouting/";
            public const string SendEmail = Prefix + "SendEmail";
        }
        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department/";
            public const string List = Prefix + "List";
            public const string GetListDepartmentStudentCount = Prefix + "GetListDepartmentStudentCount";
            public const string GetListDepartmentStudentCountWithProc = Prefix + "GetListDepartmentStudentCountWithProc/{id}";
            public const string GetById = Prefix + "id";
            public const string AddDepartment = Prefix + "AddDepartment";
            public const string DeleteDepartment = Prefix + "DeleteDepartment/{id}";
            public const string EditDepartment = Prefix + "EditDepartment";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "{id}";
            public const string Paginated = Prefix + "Paginated";

        }
        public static class ApplicationUserRouting
        {
            public const string Prefix = Rule + "User/";
            public const string List = Prefix + "List";
            public const string GetById = Prefix + "{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "{id}";
            public const string Paginated = Prefix + "Paginated";
            public const string ChangePassword = Prefix + "ChangePassword";
            public const string SendResetPassword = Prefix + "SendResetPassword";
            public const string ConfirmResetPassword = Prefix + "ConfirmResetPassword";

        }
        public static class Authentication
        {
            public const string Prefix = Rule + "Authentication/";
            public const string RefreshToken = Prefix + "RefreshToken";
            public const string SignIn = Prefix + "SignIn";
            public const string ValidateToken = Prefix + "ValidateToken";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "{id}";
            public const string Paginated = Prefix + "Paginated";
            public const string ChangePassword = Prefix + "ChangePassword";
            public const string ResetPassword = Prefix + "ResetPassword";
            public const string ConfirmEmail = "/Api/Authentication/ConfirmEmail";


        }
        public static class Authorization
        {
            public const string Prefix = Rule + "Authorization/";
            public const string CreateRole = Prefix + "CreateRole";
            public const string EditRole = Prefix + "EditRole";
            public const string EditUserClaims = Prefix + "EditUserClaims";
            public const string EditUserRole = Prefix + "EditUserRole";
            public const string DeleteRole = Prefix + "{id}";
            public const string GetManagerUserClaims = Prefix + "GetManagerUserClaims/{id}";
            public const string List = Prefix + "Role/List";
            public const string Delete = Prefix + "{id}";
            public const string GetById = Prefix + "Role/{id}";
            public const string GetManagerUserRole = Prefix + "GetManagerUserRole/{id}";

        }
        public static class InstructorRouting
        {
            public const string Prefix = Rule + "InstructorRouting";
            public const string GetSalarySummationOfInstructor = Prefix + "/SalarySummationOfInstructor";
        }
    }
}
