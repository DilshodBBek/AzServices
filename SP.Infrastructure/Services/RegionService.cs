using Microsoft.EntityFrameworkCore;
using SP.Application.Repository;
using SP.Application.Services;
using SP.Domain.Entities.LocationEntities;
using SP.Infrastructure.DataAccess;

namespace SP.Infrastructure.Services;

public class RegionService : IRegionService<RegionEntity>
{
    private readonly StadiumDbContext _context;

    public RegionService(StadiumDbContext context)
    {
        _context = context;
    }

    public async Task<RegionEntity?> CreateAsync(RegionEntity location)
    {
        // Check if the RegionName is already taken
        if (_context.Districts.Where(x => x.DistrictNameUz == location.RegionNameUz).Count() is 0
            && _context.Districts.Where(x => x.DistrictNameRu == location.RegionNameRu).Count() is 0
            && _context.Districts.Where(x => x.DistrictNameEn == location.RegionNameEn).Count() is 0)
        {
            await _context.AddAsync(location);
            _context?.SaveChangesAsync();
            return location;
        }
        else
        {
            return null;
        }
    }

    public async Task<bool> Delete(int id)
    {
        var deleteRegion = await _context.Regions.FirstAsync(x => x.RegionId == id);
        if (deleteRegion != null)
        {
            _context.Regions.Remove(deleteRegion);
            _context.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> Update(RegionEntity location)
    {
        var updateRegion = _context.Regions.FirstOrDefault(x => x.RegionId == location.RegionId);
        if (updateRegion != null)
        {
            updateRegion.RegionNameUz = location.RegionNameUz;
            updateRegion.RegionNameRu = location.RegionNameRu;
            updateRegion.RegionNameEn = location.RegionNameEn;
            _context.Regions.Update(updateRegion);
            _context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public RegionEntity? GetById(int id)
    {
        var getRegion = _context.Regions.FirstOrDefault(x => x.RegionId == Convert.ToInt32(id));
        if (getRegion != null)
        {
            return getRegion;
        }
        else
        {
            return null;
        }
    }

    IEnumerable<RegionEntity> IRepository<RegionEntity>.GetAll()
    {
        return _context.Regions.ToList();
    }
}
