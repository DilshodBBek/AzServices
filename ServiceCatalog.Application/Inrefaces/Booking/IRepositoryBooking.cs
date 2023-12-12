using ServiceCatalog.Application.Inrefaces.Base;
using ServiceCatalog.Domain.Entity.Playstation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Inrefaces.Booking
{
    public interface IRepositoryBooking:
		ICreateService<Domain.Entity.Booking.BookingPlaystation>,
		IUpdateService<Domain.Entity.Booking.BookingPlaystation>,
		IGetByIdService<Domain.Entity.Booking.BookingPlaystation>,
		IDeleteService,
		IGetAllService<Domain.Entity.Booking.BookingPlaystation>
	{
	}
}
