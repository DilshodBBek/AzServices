using Microsoft.AspNetCore.Mvc;
using ServiceCatalog.Domain.DTO.Booking;
using ServiceCatalog.Domain.Entity.Playstation;

namespace ServiceCatalog.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookingController:ControllerBase
    {
        public void BronningCategory( /* Category Id*/ /*User user*/ BookingCreateDTO<Cabin> dTO)
        {
            
        }
    }
}
