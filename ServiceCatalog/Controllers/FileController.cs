using Microsoft.AspNetCore.Mvc;
using ServiceCatalog.Application.Inrefaces.FileContent;

namespace Payment.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FileController : ControllerBase
    {
        private readonly IFileContent _fileContent;
        public FileController(IFileContent fileContent)
        {
            _fileContent = fileContent;
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile formFile, int baseId)
        {
            bool UploadResult = await _fileContent.Upload(formFile, baseId);
            if (UploadResult) return Ok("Uploaded");
            return BadRequest("You cant upload");
        }
        [HttpGet("{baseId}")]
        public IActionResult DownloadFile(int baseId)
        {
            try
            {
                var fileStream = _fileContent.Download(baseId);

                if (fileStream == null)
                {
                    return NotFound(); // или другой код состояния, если файл не найден
                }

                // Определение MIME-типа файла
                string contentType = "application/octet-stream"; // или другой подходящий MIME-тип

                // Возвращение файла в ответе
                return File(fileStream, contentType, $"{baseId}_downloaded_file");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }


    }

}


