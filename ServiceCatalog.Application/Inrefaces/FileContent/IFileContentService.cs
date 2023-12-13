using Microsoft.AspNetCore.Http;
using ServiceCatalog.Application.Inrefaces.Base;

namespace ServiceCatalog.Application.Inrefaces.FileContent
{
    public interface IFileContentService
    {
        public Task<string> Upload(IFormFile formFile, int baseId, int categoryId);
        public Task<IFormFile> Download(string path);
        public Task<bool> Delete(string path);
        public Task<bool> Create(Domain.Entity.File.FileContent obj);
    }
}
