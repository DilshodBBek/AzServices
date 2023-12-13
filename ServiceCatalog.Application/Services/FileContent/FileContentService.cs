using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ServiceCatalog.Application.Inrefaces.FileContent;

namespace ServiceCatalog.Application.Services.FileContent
{
    public class FileContentService : IFileContentService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileContentRepository _db;

        public FileContentService(IWebHostEnvironment webHostEnvironment, IFileContentRepository db)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        public async Task<bool> Create(Domain.Entity.File.FileContent obj) => await _db.Create(obj);
        public Task<bool> Delete(string fileName) => _db.DeleteByFileName(fileName);
        public async Task<IFormFile> Download(string path)
        {
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists) return null;
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

            string uploadsFolder = Path.Combine(_webHostEnvironment.ContentRootPath,"Uploads");

            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
                await formFile.CopyToAsync(stream);
            return filePath;
        }

    }
}
