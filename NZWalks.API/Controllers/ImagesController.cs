using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {

            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDTO request) 
        {
            var allowedExtensions = new string[] { ".jpg", "jped", ".png" };

            if(!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (request.File.Length > 10485760) 
            {
                ModelState.AddModelError("file", "File size is too large (>10MB)");
            }
        }

    }
}
