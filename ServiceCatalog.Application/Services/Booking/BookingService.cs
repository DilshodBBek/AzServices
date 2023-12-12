using ServiceCatalog.Application.Inrefaces.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Application.Services.Booking
{
    public class BookingService : IServiceBooking
    {
		private readonly IRepositoryBooking _bookingRepository;
        public BookingService(IRepositoryBooking cRUDRepositoryBooking)
        {
            _bookingRepository = cRUDRepositoryBooking;
        }
        public Task<bool> Create(Domain.Entity.Booking.BookingPlaystation obj)
		{
			var res = _bookingRepository.Create(obj);
			return res;
		}

		public Task<bool> Delete(int Id)
		{
			var res = _bookingRepository.Delete(Id);
			return res;
		}

		public Task<IEnumerable<Domain.Entity.Booking.BookingPlaystation>> GetAll()
		{
			var res = _bookingRepository.GetAll();
			return res;
		}

		public Task<Domain.Entity.Booking.BookingPlaystation> GetById(int Id)
		{
			var res = _bookingRepository.GetById(Id);
			return res;
		}

		public Task<bool> Update(Domain.Entity.Booking.BookingPlaystation entity)
		{
			var res = _bookingRepository.Update(entity);
			return res;
		}
	}
}
