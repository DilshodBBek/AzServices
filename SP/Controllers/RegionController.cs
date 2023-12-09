using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SP.Application.Services;
using SP.Domain.Entities.LocationEntities;
using SP.Domain.Models;
using SP.Domain.Models.RegionDTO;

namespace SP.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RegionController : ControllerBase
{
    private readonly IRegionService _regionService;
    private readonly IMapper _mapper;

    public RegionController(IRegionService regionService)
    {
        _regionService = regionService;
    }
     
    [HttpPost]
    public async Task<ResponseModel<bool>> CreateAsync(RegionCreateDTO regionCreateDTO)
    {
        var mappedRegion = new RegionEntity
        {
            RegionName = regionCreateDTO.RegionName
        };

        var regionEntity = new RegionCreateDTO
        {
            RegionName = mappedRegion.RegionName
        };

        return new(await _regionService.CreateAsync(mappedRegion));
    }

    [HttpGet]
    public async Task<ResponseModel<IEnumerable<RegionGetDTO>>> GetAll()
    {
        IEnumerable<RegionGetDTO> regionGetDTOs;

        regionGetDTOs = (await _regionService.GetAllAsync())
            .Select(x => new RegionGetDTO
            {
                RegionName = x.RegionName
            });

        return new(regionGetDTOs);
    }

    [HttpPut]
    public async Task<ResponseModel<RegionGetDTO>> Update([FromBody] RegionUpdateRegion regionUpdateRegionDTO)
    {
        RegionEntity mapped = _mapper.Map<RegionEntity>(regionUpdateRegionDTO);
        bool res = await _regionService.UpdateAsync(mapped);
        RegionGetDTO regionGetDTO = _mapper.Map<RegionGetDTO>(mapped);

        return new(regionGetDTO);
    }

}
