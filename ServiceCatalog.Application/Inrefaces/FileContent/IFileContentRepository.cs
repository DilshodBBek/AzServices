using ServiceCatalog.Application.Inrefaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Inrefaces.FileContent
{
    public interface IFileContentRepository :
        ICreateService<Domain.Entity.File.FileContent>,
        IDeleteService,
        IGetByIdService<Domain.Entity.File.FileContent>,
        IGetAllService<Domain.Entity.File.FileContent>
    {
       public Task<bool> DeleteByFileName(string fileName);
    }
}
