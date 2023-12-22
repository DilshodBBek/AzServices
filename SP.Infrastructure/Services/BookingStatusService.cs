using Microsoft.EntityFrameworkCore;
using SP.Application.Services;
using SP.Domain.Entities.BookingEntity;
using SP.Infrastructure.DataAccess;

namespace SP.Infrastructure.Services;

public class BookingStatusService : IBookingStatusService<BookingStatusEntity>
{
    private readonly StadiumDbContext _context;

    public BookingStatusService(StadiumDbContext context)
    {
        _context = context;
    }

    public async Task<BookingStatusEntity> CreateAsync(BookingStatusEntity bookingStatus)
    {
        if (_context.Bookings.Where(x => x.BookingStatusNameUz == bookingStatus.BookingStatusNameUz).Count() is 0
            && _context.Bookings.Where(x => x.BookingStatusNameRu == bookingStatus.BookingStatusNameRu).Count() is 0
            && _context.Bookings.Where(x => x.BookingStatusNameEn == bookingStatus.BookingStatusNameEn).Count() is 0)
        {
            await _context.AddAsync(bookingStatus);
            _context?.SaveChangesAsync();
            return bookingStatus;
        }
        else
        {
            return null;
        }
    }

    public async Task<bool> Delete(int id)
    {
        var deleteBookings = await _context.Bookings.FirstAsync(x => x.BookingStatusId == id);
        if (deleteBookings != null)
        {
            _context.Bookings.Remove(deleteBookings);
            _context.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerable<BookingStatusEntity> GetAll()
    {
        return _context.Bookings.ToList();
    }

    public BookingStatusEntity GetById(int id)
    {
        var getBookings = _context.Bookings.FirstOrDefault(x => x.BookingStatusId == id);
        if (getBookings != null)
            return getBookings;
        else
            return null;
    }

    public async Task<bool> Update(BookingStatusEntity bookingStatus)
    {
        var updateBooking = _context.Bookings.FirstOrDefault(x => x.BookingStatusId == bookingStatus.BookingStatusId);
        if (updateBooking != null)
        {
            updateBooking.BookingStatusNameUz = bookingStatus.BookingStatusNameUz;
            updateBooking.BookingStatusNameRu = bookingStatus.BookingStatusNameRu;
            updateBooking.BookingStatusNameEn = bookingStatus.BookingStatusNameEn;
            _context.Bookings.Update(updateBooking);
            _context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
}
