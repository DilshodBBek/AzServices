using Microsoft.AspNetCore.Mvc;
using ServiceCatalog.Application.Inrefaces.FileContent;
using System.Net.Mime;

namespace Payment.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FileController : ControllerBase
    {
        private readonly IFileContent _fileContent;
        private readonly ILogger _logger;
        public FileController(IFileContent fileContent, ILogger logger)
        {
            _logger = logger;
            _fileContent = fileContent;
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile formFile)
        {
            bool UploadResult = await _fileContent.Upload(formFile);
            if (UploadResult) return Ok("Uploaded");
            return BadRequest("You cant upload");
        }
        [HttpGet]
        public async Task<IActionResult> DownloadFile(string path)
        {
            try
            {
                var file = await _fileContent.Download(path);
                if (file == null) return NotFound(); 
       
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    string contentType = "application/octet-stream"; 
                    var contentDisposition = new ContentDisposition
                    {
                        FileName = "_downloaded_file",
                        Inline = false 
                    };
                    Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
                    return File(fileBytes, contentType);
                }
            }
            catch (Exception ex)
            {
                // Log the exception for troubleshooting
                _logger.LogError(ex, "An error occurred while downloading the file.");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}

