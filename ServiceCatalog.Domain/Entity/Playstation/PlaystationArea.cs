using ServiceCatalog.Domain.Entity.Common;
namespace ServiceCatalog.Domain.Entity.Playstation;
public class PlaystationArea:Base
{
    //Sp
    public int CategoryId { get; } = 1;
    public List<Cabin> Сabins { get; set; }
}
