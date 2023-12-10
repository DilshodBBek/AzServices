using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceCatalog.Application.Inrefaces.Playstation;
using ServiceCatalog.Domain.DTO.Playstation;
using ServiceCatalog.Domain.Entity.Playstation;
using ServiceCatalog.Domain.Entity.ResponseModel;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace ServiceCatalog.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PlaystationAreaController:ControllerBase
    {
        private readonly IServicePlaystationArea _service;
        private readonly IMapper  _mapper;
        public PlaystationAreaController(IServicePlaystationArea service, IMapper mapper)
        {
            _mapper = mapper;
            _service =service;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlaystation(PlaystationCreateDTO obj)
        {
            PlaystationArea play = _mapper.Map<PlaystationArea>(obj);
            var createdPlay=await _service.Create(play);
            if (createdPlay) return Ok();
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdPlaystation(int Id)
        {
            var createdPlaystation = await _service.GetById(Id);
            if (createdPlaystation != null) return Ok(createdPlaystation);
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlaystation()
        {
            var playstations = await _service.GetAll();
            if (playstations.Count()>=1) return Ok(playstations);
            return BadRequest();
        }
        [HttpDelete]
        public async Task<ResponseModel<bool>> DeletePlaystation(int Id)
        {
            var DeletePlaystation = await _service.Delete(Id);
            if (DeletePlaystation) return new(DeletePlaystation,HttpStatusCode.Accepted);
            return new(DeletePlaystation, HttpStatusCode.BadRequest);
        }
        [HttpPut]
        public async Task<ResponseModel<bool>> UpdatePlaystation(PlaystationUpdateDTO obj)
        {
            var deleteObj= _mapper.Map<PlaystationArea>(obj);
            bool UpdatePlaystation = await _service.Update(deleteObj);
            if (UpdatePlaystation) return new(UpdatePlaystation);
            return new(UpdatePlaystation, HttpStatusCode.Conflict);
        }
        [HttpGet]
        public async Task<ResponseModel<IEnumerable<PlaystationArea>>> GetPlaystationPage(int page,int pageSize)
        {
            var Playstations= await _service.GetAll();
            var PaginatedList= Playstations
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
            if (PaginatedList.Count < 1) return new("This page is empty",HttpStatusCode.BadGateway);
            return new(PaginatedList,HttpStatusCode.Accepted);
        }
    }
}
