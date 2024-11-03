using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Servies.Implementation
{
    public class FileServies : IFileServies
    {
        #region Fields
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region Constructors
        public FileServies(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Handle Functions
        public async Task<string> UploadImage(string location, IFormFile file)
        {
            //Get Location
            var path = _webHostEnvironment.WebRootPath + "/" + location + "/";

            #region Check Extension
            var extension = Path.GetExtension(file.FileName);
            var allowExtensions = new string[] { ".JPG", ".PNG", ".SVG" };
            var extensionComparer = allowExtensions.Contains(extension, StringComparer.InvariantCultureIgnoreCase);
            if (!extensionComparer)
                return "this extension is not allowed";
            #endregion

            #region Check Image Size
            var allowedSize = file.Length is > 0 and < 4_000_000;
            if (!allowedSize)
                return "this image is too big";
            #endregion

            #region Store Image
            var newFileName = $"{Guid.NewGuid().ToString().Replace("-", string.Empty)}{extension}";
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream filestreem = File.Create(path + newFileName))
                {
                    await file.CopyToAsync(filestreem);
                    await filestreem.FlushAsync();
                    return $"/{location}/{newFileName}";
                }
            }
            catch (Exception)
            {
                return "FailedToUploadImage";
            }
            #endregion
        }

        #endregion
    }
}
