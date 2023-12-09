using System.ComponentModel.DataAnnotations;

namespace SP.Domain.Entities.LocationEntities;

public class DistrictEntity
{
    [Key]
    public int DistrictId { get; set; }
    public string? DistrictName { get; set; }
}
