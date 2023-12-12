using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ServiceCatalog.Application.Inrefaces.FileContent;

namespace ServiceCatalog.Application.Services.FileContent
{
    public class FileContentService : IFileContent
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileContentService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IFormFile> Download(string path)
        {
            // Assuming 'path' is the physical path to the file
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists) return null;
            // Create an IFormFile representation of the file
            var formFile = new FormFile(
                baseStream: new FileStream(fileInfo.FullName, FileMode.Open),
                baseStreamOffset: 0,
                length: fileInfo.Length,
                name: "file",
                fileName: fileInfo.Name
            );

            return formFile;
        }

        public async Task<string> Upload(IFormFile formFile, int baseId, int categoryId)
        {
            if (formFile == null || formFile.Length == 0) return "";
            string uniqueFileName = $"{Guid.NewGuid()}_{formFile.FileName}";

            string uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "uploads");

            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            Directory.CreateDirectory(uploadsFolder);

            using (var stream = new FileStream(filePath, FileMode.Create))
                await formFile.CopyToAsync(stream);
            return filePath;
        }
    }
}
