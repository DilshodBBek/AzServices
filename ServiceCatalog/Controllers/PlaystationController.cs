using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceCatalog.Application.Inrefaces.Playstation;
using ServiceCatalog.Domain.DTO.Playstation;
using ServiceCatalog.Domain.Entity.Playstation;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace ServiceCatalog.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PlaystationAreaController:Controller
    {
        private readonly ICRUDServicePlaystationArea _service;
        private readonly IMapper  _mapper;
        public PlaystationAreaController(ICRUDServicePlaystationArea service, IMapper mapper)
        {
            _mapper = mapper;
            _service =service;
        }
        public async Task<string> CreatePlaystationArea(PlaystationCreateDTO obj)
        {
            PlaystationArea play = _mapper.Map<PlaystationArea>(obj);
            var createdPlay=await _service.Create(play);
            if (createdPlay) return "Created";
            return "You cant create";
        }
        public async Task<IActionResult> GetById(int Id)
        {
            var createdPlay = await _service.GetById(Id);
            if (createdPlay!=null) return Ok(createdPlay);
            return "You cant create";
        }
    }
}
