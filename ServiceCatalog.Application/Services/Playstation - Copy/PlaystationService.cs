using Microsoft.AspNetCore.Mvc;
using ServiceCatalog.Application.Inrefaces.Pagination;
using ServiceCatalog.Application.Inrefaces.Playstation;
using ServiceCatalog.Domain.Entity.Playstation;

namespace ServiceCatalog.Application.Services.Playstation
{
    public class PlaystationService : IServicePlaystationArea
    {
        private readonly IRepositoryPlaystationArea _service;

        public PlaystationService(IRepositoryPlaystationArea service)
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

        public async Task<PaginatedList<PlaystationArea>> GetQuery(int pageIndex, int countElementInPage)
        {
          var result= await _service.GetQuery(pageIndex, countElementInPage);
            return result;
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
