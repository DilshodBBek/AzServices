using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ServiceCatalog.Application.Inrefaces.FileContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Services.FileContent
{
    public class FileContentService : IFileContent
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileContentService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<bool> Upload(IFormFile formFile, int baseId)
        {
            if (formFile == null || formFile.Length == 0) return false;
            string uniqueFileName = $"{baseId}_{Guid.NewGuid()}_{formFile.FileName}";

            string uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "uploads");

            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            Directory.CreateDirectory(uploadsFolder);

            using (var stream = new FileStream(filePath, FileMode.Create))
                await formFile.CopyToAsync(stream);
            return true;    
        }
    }
}
