using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceCatalog.Application.Inrefaces.Playstation;
using ServiceCatalog.Domain.DTO.Playstation;
using ServiceCatalog.Domain.Entity.Playstation;
using System.ComponentModel;
using System.Data;
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
        [HttpPost]
        public async Task<IActionResult> CreatePlaystation(PlaystationCreateDTO obj)
        {
            PlaystationArea play = _mapper.Map<PlaystationArea>(obj);
            var createdPlay=await _service.Create(play);
            if (createdPlay) return Ok("Created");
            return BadRequest("You cant create");
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdPlaystation(int Id)
        {
            var createdPlaystation = await _service.GetById(Id);
            if (createdPlaystation != null) return Ok(createdPlaystation);
            return BadRequest("You cant create");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlaystation(int Id)
        {
            var playstations = await _service.GetAll();
            if (playstations.Count()>=1) return Ok(playstations);
            return BadRequest("Playstations empty");
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePlaystation(int Id)
        {
            var DeletePlaystation = await _service.Delete(Id);
            if (DeletePlaystation) return Ok(DeletePlaystation);
            return BadRequest("In Db not exist this object");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlaystation(PlaystationUpdateDTO obj)
        {
            var deleteObj= _mapper.Map<PlaystationArea>(obj);
            var DeletePlaystation = await _service.Update(deleteObj);
            if (DeletePlaystation) return Ok(DeletePlaystation);
            return BadRequest("In Db not exist this object");
        }
    }
}
