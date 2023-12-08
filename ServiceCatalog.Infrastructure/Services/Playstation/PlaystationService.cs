using ServiceCatalog.Application.Inrefaces.Playstation;
using ServiceCatalog.Domain.Entity.Playstation;
using ServiceCatalog.Infrastructure.Data.Contex;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Infrastructure.Services.Playstation
{
    public class PlaystationService : ICRUDServicePlaystationArea
    {
        private readonly ICRUDRepositoryPlaystationArea _service;

        public PlaystationService(ICRUDRepositoryPlaystationArea service)
        {
            _service=service;
        }
        public async Task<bool> Create(PlaystationArea obj)
        {
            var Playstation = await _service.GetById(obj.Id);
            if (Playstation != null) return false;
            await _service.Create(obj);
            return true;
        }

        public async Task<bool> Delete(int Id)
        {
           var res= await _service.Delete(Id);
            return res;
        }

        public async Task<IEnumerable<PlaystationArea>> GetAll()
        {
            IEnumerable<PlaystationArea> Playstations =await _service.GetAll();
            return Playstations;
        }

        public async Task<PlaystationArea> GetById(int Id)
        {
         PlaystationArea playstation=await _service.GetById(Id);  
            return playstation; 
        }

        public async Task<bool> Update(PlaystationArea entity)
        {
            var playstation=_service.GetById(entity.Id);
            if(playstation==null) return false;
           var res=await _service.Update(entity);
            return res;
        }
    }
}
