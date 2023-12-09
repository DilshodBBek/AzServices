using Microsoft.AspNetCore.Mvc;
using ServiceCatalog.Application.Inrefaces.Playstation;
using ServiceCatalog.Domain.DTO.Playstation;
using System.ComponentModel;

namespace ServiceCatalog.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PlaystationAreaController:Controller
    {
        private readonly ICRUDServicePlaystationArea _service;
        public PlaystationAreaController(ICRUDServicePlaystationArea service )
        {
            _service=service;
        }
        //public string CreatePlaystationArea(PlaystationCreateDTO obj)
        //{
        //    _service.Create(obj);

        //}
    }
}
