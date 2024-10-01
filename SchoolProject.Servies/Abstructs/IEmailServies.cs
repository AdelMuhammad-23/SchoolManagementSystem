namespace SchoolProject.Servies.Abstructs
{
    public interface IEmailServies
    {
        public Task<string> SendEmailAsync(string email, string massage);
    }
}
