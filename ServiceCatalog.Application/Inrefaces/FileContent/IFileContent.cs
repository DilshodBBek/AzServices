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
        public Task<bool> Upload(IFormFile file,int baseId);
    }
}
