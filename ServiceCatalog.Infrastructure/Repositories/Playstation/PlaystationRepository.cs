using Microsoft.EntityFrameworkCore;
using ServiceCatalog.Application.Inrefaces.Playstation;
using ServiceCatalog.Domain.Entity.Playstation;
using ServiceCatalog.Infrastructure.Data.Contex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Infrastructure.Repositories.Playstation
{
    public class PlaystationRepository : ICRUDRepositoryPlaystationArea
    {
        private readonly AppDbContext _db;
        public PlaystationRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(PlaystationArea obj)
        {
           await _db.Playstations.AddAsync(obj);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int Id)
        {
            var objForDelete = await GetById(Id);
            if (objForDelete == null) return false;
            _db.Playstations.Remove(objForDelete);
            _db.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<PlaystationArea>> GetAll()
        {
            var Playstations = _db.Playstations.AsNoTracking();
            return Playstations;
        }

        public async Task<PlaystationArea?> GetById(int Id)
        {
            var Playstation = await _db.Playstations.FindAsync(Id);
            return Playstation;
        }

        public async Task<bool> Update(PlaystationArea entity)
        {
          _db.Playstations.Update(entity);
          await  _db.SaveChangesAsync();
            return true;
        }
    }
}
