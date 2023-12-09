using ServiceCatalog.Application.Inrefaces.Base;
using ServiceCatalog.Domain.Entity.Playstation;

namespace ServiceCatalog.Application.Inrefaces.Stadiums;

public interface ICRUDServiceStadium :
    ICreateService<PlaystationArea>,
    IUpdateService<PlaystationArea>,
    IGetByIdService<PlaystationArea>,
    IDeleteService,
    IGetAllService<PlaystationArea>
{
}
