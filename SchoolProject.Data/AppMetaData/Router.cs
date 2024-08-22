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
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + "{id}";

        }
    }
}
