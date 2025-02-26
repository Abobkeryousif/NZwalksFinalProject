namespace NZwalks.Api.Models.DTO
{
    public class UploadImageRequestDTO
    {
        public IFormFile File { get; set; }

        public string FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
