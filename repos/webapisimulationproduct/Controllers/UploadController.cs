using coresimulation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapisimulationproduct.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UploadController : ControllerBase
    {
        private readonly UploadFile _uploadfile;
        private readonly DownloadFile _downloadfile;

        public UploadController(UploadFile uploadFile, DownloadFile downloadFile) { 
            _uploadfile = uploadFile;
            _downloadfile = downloadFile;
        }

        [HttpPost]
        public IActionResult Upload(IFormFile formFile) {
            return Ok(_uploadfile.Upload(formFile));
        }

        [HttpGet("downloaduploadedfile/{filename}")]
        public IActionResult Download(string filename)
        {
            var result = _downloadfile.Download(filename);

            if (result == null)
                return NotFound("File not found.");

            return File(result.Value.fileData, result.Value.contentType, result.Value.fileName);
        }

    }
}
