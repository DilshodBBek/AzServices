using ServiceCatalog.Application.Inrefaces.Base;
using ServiceCatalog.Application.Inrefaces.Pagination;
using ServiceCatalog.Domain.Entity.Playstation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Inrefaces.Playstation
{
    public interface IServicePlaystationArea : 
        ICreateService<PlaystationArea>,
        IUpdateService<PlaystationArea>,
        IGetByIdService<PlaystationArea>,
        IDeleteService,
        IGetAllService<PlaystationArea>
    {
        public Task<PaginatedList<PlaystationArea>> GetQuery(int pageIndex, int countElementInPage);
    }
}
