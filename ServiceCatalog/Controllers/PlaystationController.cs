using Microsoft.AspNetCore.Mvc;
using ServiceCatalog.Domain.DTO.Playstation;
using System.ComponentModel;

namespace ServiceCatalog.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PlaystationAreaController:Controller
    {
        public PlaystationAreaController()
        {
            
        }
        public string CreatePlaystationArea(PlaystationCreateDTO obj)
        {

        }
    }
}
