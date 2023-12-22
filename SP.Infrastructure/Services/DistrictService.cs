using Microsoft.EntityFrameworkCore;
using SP.Application.Services;
using SP.Domain.Entities.LocationEntities;
using SP.Infrastructure.DataAccess;

namespace SP.Infrastructure.Services;

public class DistrictService : IDistrictService<DistrictEntity>
{
    private readonly StadiumDbContext _context;

    public DistrictService(StadiumDbContext context)
    {
        _context = context;
    }

    public async Task<DistrictEntity> CreateAsync(DistrictEntity location)
    {
        // Check if the DistrictName is already taken
        if(_context.Districts.Where(x => x.DistrictNameUz == location.DistrictNameUz).Count() is 0
            && _context.Districts.Where(x => x.DistrictNameRu == location.DistrictNameRu).Count() is 0
            && _context.Districts.Where(x => x.DistrictNameEn == location.DistrictNameEn).Count() is 0)
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
        var deleteDistrict = await _context.Districts.FirstAsync( x => x.DistrictId == id);
        if(deleteDistrict != null)
        {
            _context.Districts.Remove(deleteDistrict);
            _context.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerable<DistrictEntity> GetAll()
    {
        return _context.Districts.ToList();
    }

    public DistrictEntity? GetById(int id)
    {
        var getDistrict = _context.Districts.FirstOrDefault(x => x.DistrictId == id);
        if (getDistrict != null)
            return getDistrict;
        else
            return null;
    }

    public async Task<bool> Update(DistrictEntity location)
    {
        var updateDistrict = _context.Districts.FirstOrDefault(x => x.DistrictId == location.DistrictId);
        if(updateDistrict != null)
        {
            updateDistrict.DistrictNameUz = location.DistrictNameUz;
            updateDistrict.DistrictNameRu = location.DistrictNameRu;
            updateDistrict.DistrictNameEn = location.DistrictNameEn;
            _context.Districts.Update(updateDistrict);
            _context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
}
