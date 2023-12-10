using ServiceCatalog.Application.Inrefaces.Base;
using ServiceCatalog.Domain.Entity.Playstation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Inrefaces.Stadiums
{
	public interface IServiceStadium:
		ICreateService<PlaystationArea>,
		IUpdateService<PlaystationArea>,
		IGetByIdService<PlaystationArea>,
		IDeleteService,
		IGetAllService<PlaystationArea>
	{
	}
}
