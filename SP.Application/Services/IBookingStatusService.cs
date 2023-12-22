using SP.Application.Repository;
using SP.Domain.Entities.BookingEntity;

namespace SP.Application.Services;

public interface IBookingStatusService<T> : IRepository<BookingStatusEntity>
{
}
