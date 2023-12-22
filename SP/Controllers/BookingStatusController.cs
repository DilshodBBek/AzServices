using Microsoft.AspNetCore.Mvc;
using SP.Application.Services;
using SP.Domain.Entities.BookingEntity;
using SP.Domain.Models;

namespace SP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingStatusController : ControllerBase
    {
        private readonly IBookingStatusService<BookingStatusEntity> _bookingService;
        private readonly ILogger<DistrictController> _logger;

        public BookingStatusController(ILogger<DistrictController> logger, IBookingStatusService<BookingStatusEntity> bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<ResponseModel<BookingStatusEntity>> CreateAsync(BookingStatusEntity bookings)
        {
            Task<BookingStatusEntity> createdBooking = _bookingService.CreateAsync(bookings);
            return new(bookings);
        }

        [HttpGet]
        public async Task<ResponseModel<IEnumerable<BookingStatusEntity>>> GetAll()
        {
            IEnumerable<BookingStatusEntity> getAllBookings = _bookingService.GetAll();
            return new(getAllBookings);
        }

        [HttpPut]
        public async Task<ResponseModel<bool>> Update(int id, [FromBody] BookingStatusEntity bookingStatus)
        {
            bool mappedBookings = await _bookingService.Update(bookingStatus);
            return new(mappedBookings);
        }

        [HttpDelete]
        public async Task<ResponseModel<bool>> DeleteAsync(int id)
        {
            try
            {
                bool deleteId = await _bookingService.Delete(id);
                string s = deleteId ? "Delete" : "There is no Id";
                return new(deleteId);
            }
            catch
            {
                return new(false);
            }
        }

        [HttpGet]
        public BookingStatusEntity GetById(int id)
        {
            BookingStatusEntity getById = _bookingService.GetById(id);
            return getById;
        }
    }
}
