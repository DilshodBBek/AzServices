using ServiceCatalog.Application.Inrefaces.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCatalog.Domain.Entity;

namespace ServiceCatalog.Infrastructure.Repositories.Booking
{
	public class BookingRepository : ICRUDRepositoryBooking
	{
		public Task<bool> Create(Domain.Entity.Booking obj)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int Id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Domain.Entity.Booking>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<Domain.Entity.Booking> GetById(int Id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(Domain.Entity.Booking entity)
		{
			throw new NotImplementedException();
		}
	}
}
