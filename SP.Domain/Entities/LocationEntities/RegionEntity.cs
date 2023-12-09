using System.ComponentModel.DataAnnotations;

namespace SP.Domain.Entities.LocationEntities;

public class RegionEntity
{
    [Key]
    public int RegionId { get; set; }
    public string? RegionName { get; set; }
}
