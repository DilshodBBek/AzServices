using Microsoft.AspNetCore.Mvc;
using SP.Application.Services;
using SP.Domain.Entities.LocationEntities;
using SP.Domain.Models;

namespace SP.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RegionController : ControllerBase
{
    private readonly IRegionService<RegionEntity> _regionService;
    private readonly ILogger<RegionController> _logger;

    public RegionController(IRegionService<RegionEntity> regionService, ILogger<RegionController> logger)
    {
        _regionService = regionService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ResponseModel<RegionEntity>> CreateAsync(RegionEntity location)
    {
        Task<RegionEntity> createdRegion = _regionService.CreateAsync(location);
        return new(location);
    }

    [HttpGet]
    public async Task<ResponseModel<IEnumerable<RegionEntity>>> GetAll()
    {
        IEnumerable<RegionEntity> getAllRegions = _regionService.GetAll();
        return new(getAllRegions);
    }

    [HttpPut]
    public async Task<ResponseModel<bool>> Update(int id, [FromBody] RegionEntity location)
    {
        bool mapped = await _regionService.Update(location);
        return new(mapped);
    }

    [HttpDelete]
    public async Task<ResponseModel<bool>> DeleteAsync(int id)
    {
        try
        {
            bool deletedId = await _regionService.Delete(id);
            string s = deletedId ? "Delete" : "There is no Id";
            return new(s);
        }
        catch
        {

            return new(false);
        }
    }

    [HttpGet]
    public RegionEntity GetById(int id)
    {
        RegionEntity getById = _regionService.GetById(id);
        return getById;
    }
}
