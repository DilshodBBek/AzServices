using System.ComponentModel.DataAnnotations;

namespace SP.Domain.Entities.BookingEntity;

public class BookingStatusEntity
{
    [Key]
    public int BookingStatusId { get; set; }
    public string? BookingStatusNameUz { get; set; }
    public string? BookingStatusNameRu { get; set; }
    public string? BookingStatusNameEn { get; set; }
}
