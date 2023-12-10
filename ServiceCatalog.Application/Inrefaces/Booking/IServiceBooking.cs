using ServiceCatalog.Application.Inrefaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Inrefaces.Booking
{
    public interface IServiceBooking : 
        ICreateService<Domain.Entity.Booking.Booking>,
        IUpdateService<Domain.Entity.Booking.Booking>,
        IGetByIdService<Domain.Entity.Booking.Booking>,
        IDeleteService,
        IGetAllService<Domain.Entity.Booking.Booking>
    {
    }
}
