using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Inrefaces.FileContent
{
    public interface IFileContent
    {
        public Task<string> Upload(IFormFile formFile, int baseId, int categoryId);
        public Task<IFormFile> Download(string path);
    }
}
