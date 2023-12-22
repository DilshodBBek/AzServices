using Microsoft.AspNetCore.Mvc;
using SP.Application.Services;
using SP.Domain.Entities.LocationEntities;
using SP.Domain.Models;

namespace SP.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DistrictController : ControllerBase
{
    private readonly IDistrictService<DistrictEntity> _districtService;
    private readonly ILogger<DistrictController> _logger;

    public DistrictController(IDistrictService<DistrictEntity> districtService, ILogger<DistrictController> logger)
    {
        _districtService = districtService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ResponseModel<DistrictEntity>> CreateAsync(DistrictEntity district)
    {
        Task<DistrictEntity> createdDistrict = _districtService.CreateAsync(district);
        return new(district);
    }

    [HttpGet]
    public async Task<ResponseModel<IEnumerable<DistrictEntity>>> GetAll()
    {
        IEnumerable<DistrictEntity> getAllDistricts = _districtService.GetAll();
        return new(getAllDistricts);
    }

    [HttpPut]
    public async Task<ResponseModel<bool>> Update(int id, [FromBody] DistrictEntity district)
    {
        bool mappedDistrict = await _districtService.Update(district);
        return new(mappedDistrict);
    }

    [HttpDelete]
    public async Task<ResponseModel<bool>> DeleteAsync(int id)
    {
        try
        {
            bool deletedId = await _districtService.Delete(id);
            string s = deletedId ? "Delete" : "There is no Id";
            return new(s);
        }
        catch
        {
            return new(false); ;
        }
    }

    [HttpGet]
    public DistrictEntity GetById(int id)
    {
        DistrictEntity getById = _districtService.GetById(id);
        return getById;
    }
}
