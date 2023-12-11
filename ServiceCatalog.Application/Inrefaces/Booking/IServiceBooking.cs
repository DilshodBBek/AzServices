using ServiceCatalog.Application.Inrefaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Inrefaces.Booking
{
    public interface IServiceBooking : 
        ICreateService<Domain.Entity.Booking.BookingPlaystation>,
        IUpdateService<Domain.Entity.Booking.BookingPlaystation>,
        IGetByIdService<Domain.Entity.Booking.BookingPlaystation>,
        IDeleteService,
        IGetAllService<Domain.Entity.Booking.BookingPlaystation>
    {
    }
}
