using SP.Application.Repository;
using SP.Application.Services;
using SP.Domain.Entities.LocationEntities;
using SP.Domain.Models;
using SP.Domain.Models.RegionDTO;
using SP.Infrastructure.DataAccess;

namespace SP.Infrastructure.Services;

public class RegionService : IRegionService
{
    private readonly StadiumDbContext _stadiumDbContext;

    public RegionService(StadiumDbContext stadiumDbContext)
    {
        _stadiumDbContext = stadiumDbContext;
    }

    public async Task<bool> CreateAsync(RegionEntity entity)
    {
        await _stadiumDbContext.Regions.AddAsync(entity);
        int effectedRows = await _stadiumDbContext.SaveChangesAsync();
        return effectedRows > 0;
    }

    public async Task<bool> DeleteAsync(int Id)
    {
        var entity = await _stadiumDbContext.Regions.FindAsync(Id);
        if (entity == null)
            return false;

        _stadiumDbContext.Remove(entity);
        await _stadiumDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<ResponseModel<IEnumerable<RegionGetDTO>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<RegionEntity> GetByIdAsync(int Id)
    {
        var regionEntity = await _stadiumDbContext.Regions.FindAsync(Id);
        return regionEntity;
    }

    public async Task<bool> UpdateAsync(RegionEntity entity)
    {
        _stadiumDbContext.Regions.Update(entity);
        var executedRows = await _stadiumDbContext.SaveChangesAsync();

        return executedRows > 0;
    }

    Task<IEnumerable<RegionEntity>> IRepository<RegionEntity>.GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
