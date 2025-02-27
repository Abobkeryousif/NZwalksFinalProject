using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZwalks.Api.Models.Domain;
using NZwalks.Api.Models.DTO;
using NZwalks.Api.Repostries;

namespace NZwalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
        _imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]

        public async Task<IActionResult> Upload([FromForm] UploadImageRequestDTO request) 
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {
                var UploadImageDomainModel = new Image
                {
                    file = request.File,
                    FileExtension = Path.GetExtension(request.FileName),
                    SizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,
                };
                await _imageRepository.Uplaod(UploadImageDomainModel);
                return Ok(UploadImageDomainModel);
                    }

                  
                return BadRequest(ModelState);
        }

        private void ValidateFileUpload(UploadImageRequestDTO request) 
        {
            var AllowedExtension = new string[] {".jpg" , ".png" , ".jpeg" };
            if (!AllowedExtension.Contains(Path.GetExtension(request.File.FileName))) 
            {
                ModelState.AddModelError("file", "UnSupported File Extension");
            }

            if (request.File.Length > 10485760) 
            {
                ModelState.AddModelError("Length", "File Size More Then 10 MB ,plaese Upload Smaller File"); 
            }
        }
    }
}
