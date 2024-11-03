using Microsoft.AspNetCore.Http;

namespace SchoolProject.Servies.Abstructs
{
    public interface IFileServies
    {
        public Task<string> UploadImage(string location, IFormFile file);
    }
}
