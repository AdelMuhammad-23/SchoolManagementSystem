namespace SchoolProject.Core.Features.Instructors.Queries.Response
{
    public class GetInstructorListResponse
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public decimal? Salary { get; set; }
        public int DID { get; set; }
    }
}
