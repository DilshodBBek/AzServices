using ServiceCatalog.Application.Inrefaces.Base;
using ServiceCatalog.Domain.Entity.Playstation;

namespace ServiceCatalog.Application.Inrefaces.Playstation;

public interface ICRUDRepositoryPlaystationArea :
    ICreateService<PlaystationArea>,
    IUpdateService<PlaystationArea>,
    IGetByIdService<PlaystationArea>,
    IDeleteService,
    IGetAllService<PlaystationArea>
{
}
