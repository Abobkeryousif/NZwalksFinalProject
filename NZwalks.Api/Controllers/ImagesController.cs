using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZwalks.Api.Models.DTO;

namespace NZwalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost]
        [Route("Upload")]

        public async Task<IActionResult> Upload([FromForm] UploadImageRequestDTO request) 
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            { 
                
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
