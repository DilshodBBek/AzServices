using ServiceCatalog.Application.Inrefaces.Base;
using ServiceCatalog.Domain.Entity.Playstation;

namespace ServiceCatalog.Application.Inrefaces.Playstation;

public interface ICRUDServicePlaystationArea :
    ICreateService<PlaystationArea>,
    IUpdateService<PlaystationArea>,
    IGetByIdService<PlaystationArea>,
    IDeleteService,
    IGetAllService<PlaystationArea>
{
}
