using System.ComponentModel.DataAnnotations;

namespace SP.Domain.Entities.LocationEntities;

public class DistrictEntity
{
    [Key]
    public int DistrictId { get; set; }
    public string? DistrictNameUz { get; set; }
    public string? DistrictNameRu { get; set; }
    public string? DistrictNameEn { get; set; }
}
