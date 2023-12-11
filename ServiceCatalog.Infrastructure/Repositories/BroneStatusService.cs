using ServiceCatalog.Application.Inrefaces;
using ServiceCatalog.Application.Inrefaces.Playstation;
using ServiceCatalog.Domain.Entity.Playstation;
using ServiceCatalog.Infrastructure.Data.Contex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Infrastructure.Repositories
{
	public class BronePlaystationStatusService : IBroneStatusService<Cabin>
	{
		private readonly AppDbContext _db;
		public BronePlaystationStatusService(AppDbContext db)
		{
			_db = db;
		}
		public /*async*/ List<Cabin> GetStatus(int CabinaId)
		{
			//var cabina = _db.Ca
			return null;
		}
	}
}
