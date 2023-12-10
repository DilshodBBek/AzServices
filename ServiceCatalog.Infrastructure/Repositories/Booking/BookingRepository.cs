using ServiceCatalog.Application.Inrefaces.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Infrastructure.Repositories.Booking
{
    public class BookingRepository : IRepositoryBooking
	{
		public Task<bool> Create(Domain.Entity.Booking.Booking obj)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int Id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Domain.Entity.Booking.Booking>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<Domain.Entity.Booking.Booking> GetById(int Id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(Domain.Entity.Booking.Booking entity)
		{
			throw new NotImplementedException();
		}
	}
}
