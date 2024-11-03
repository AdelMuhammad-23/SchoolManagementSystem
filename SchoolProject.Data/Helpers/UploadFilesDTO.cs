namespace SchoolProject.Data.Helpers
{
    public class UploadFilesDTO
    {
        public UploadFilesDTO(bool isSuccess, string message, string url = "")
        {
            IsSuccess = isSuccess;
            Url = url;
            Message = message;
        }

        public bool IsSuccess { get; set; }
        public string Url { get; set; }
        public string Message { get; set; }
    }
}
