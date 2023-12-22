﻿using Microsoft.AspNetCore.Mvc;
using ServiceCatalog.Application.Inrefaces.FileContent;
using ServiceCatalog.Domain.Entity.File;
using System.Net.Mime;

namespace Payment.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FileController : ControllerBase
    {
        private readonly IFileContentService _fileContent;

        public FileController(IFileContentService fileContent)
        {
            _fileContent = fileContent;
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile formFile, int baseId)
        {
            string UploadResult = await _fileContent.Upload(formFile, baseId);
            if (UploadResult != "")
            {
                FileContent file = new()
                {
                    FileName = UploadResult,
                    BaseId = baseId,
                };
                await _fileContent.Create(file);
                return Ok(UploadResult);
            }
            return BadRequest("");
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
                        FileName = $"{Guid.NewGuid()}+.png",
                        Inline = false
                    };
                    Response.Headers.Add("Content-Disposition", contentDisposition.ToString());
                    return File(fileBytes, contentType);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}

