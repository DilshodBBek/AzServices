using Microsoft.EntityFrameworkCore;
using ServiceCatalog.Application.Inrefaces;
using ServiceCatalog.Application.Inrefaces.Playstation;
using ServiceCatalog.Domain.Entity.Common;
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
		public async List<Cabin> GetStatus(int CabinaId)
		{
			var cabina = _db.Cabins.Include(x=>x.BroneStatuses).FirstOrDefault(x => x.Id == CabinaId);
			List<Domain.Entity.Common.BroneStatus> status = cabina.BroneStatuses;
			DateTime currentDate = DateTime.Today;

			var allTimeRanges = Enumerable.Range(0, 24)
			.Select(hour => currentDate.AddHours(hour))
			.ToList();

			// Фильтруем и сортируем статусы
			var filteredAndSortedStatus = status
				.Where(item => item.TimeDiapazonId >= currentDate && item.TimeDiapazonId < currentDate.AddDays(1))
				.OrderBy(item => item.TimeDiapazonId)
				.ToList();

			var mergedList = allTimeRanges
			.GroupJoin(filteredAndSortedStatus,
					   range => range,
					   statusItem => statusItem.TimeDiapazonId,
					   (range, statuses) => statuses.DefaultIfEmpty(new BroneStatus { TimeDiapazonId = range, BookingStatusId = 3 }))
			.SelectMany(group => group)
			.ToList();

			//foreach (var item in filteredAndSortedStatus)
			//{
			//	//DateTime
			//	item.TimeDiapazonId
			//}
		}
	}
}
