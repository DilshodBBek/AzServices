using System.ComponentModel.DataAnnotations;

namespace SP.Domain.Entities.LocationEntities;

public class RegionEntity
{
    [Key]
    public int RegionId { get; set; }
    public string? RegionNameUz { get; set; }
    public string? RegionNameRu { get; set; }
    public string? RegionNameEn { get; set; }
}
