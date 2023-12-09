using ServiceCatalog.Application.Inrefaces.Base;
using ServiceCatalog.Domain.Entity;
using ServiceCatalog.Domain.Entity.Playstation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Inrefaces.Booking
{
	public interface ICRUDRepositoryBooking:
		ICreateService<ServiceCatalog.Domain.Entity.Booking>,
		IUpdateService<ServiceCatalog.Domain.Entity.Booking>,
		IGetByIdService<ServiceCatalog.Domain.Entity.Booking>,
		IDeleteService,
		IGetAllService<ServiceCatalog.Domain.Entity.Booking>
	{
	}
}
