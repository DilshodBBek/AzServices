using Microsoft.EntityFrameworkCore;
using ServiceCatalog.Application.Inrefaces.Brone;
using ServiceCatalog.Application.Inrefaces.Other;
using ServiceCatalog.Application.Inrefaces.Playstation;
using ServiceCatalog.Domain.DTO;
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
    public class BronePlaystationStatusService : IBroneStatusService<BroneStatusGetDTO>
	{
		private readonly AppDbContext _db;
		private readonly ICacheService _cacheService;
		public BronePlaystationStatusService(AppDbContext db, ICacheService cacheService)
		{
			_db = db;
			_cacheService = cacheService;
		}
		public BroneStatusGetDTO GetStatus(int CabinaId)
		{
			Cabin? cabina = _db.Cabins.
				 Include(x=>x.BroneStatuseId)
				.Include(x=>x.PlaystationArea)
				.FirstOrDefault(x => x.Id == CabinaId);
			
			DateTime currentDate = DateTime.Today;

			BroneStatus? PaidStatus = cabina.BroneStatuseId.
							FirstOrDefault(x=>x.Date>=currentDate && x.Date<currentDate.AddDays(1));

			BroneStatusGetDTO Statuses = new()
			{
				UnitBaseId = cabina.Id,
				Date = currentDate,
				TimeBookingStatusId = new()
			};

			foreach (var item in PaidStatus.StatuseId)
			{
				//eto iz database poetomu value = 2
				Statuses.TimeBookingStatusId.Add(item, 2);
			}

			int OpenTime = cabina.PlaystationArea.OpenTime.Hours;
			int CloseTime = cabina.PlaystationArea.CloseTime.Hours;

			for (int i=OpenTime;
						i<= CloseTime && !PaidStatus.StatuseId.Contains(i);
						i++)
			{
				bool HasInCache = _cacheService.Get($"BroneStatusId={cabina.Id},StatusId={i}");
				if (HasInCache == false)
				{
					//eto ne kotorix net v Cache toest free poetomu value = 3
					Statuses.TimeBookingStatusId.Add(i, 3);
				}
				else
				{
					//eto v Cache poetomu value = 1
					Statuses.TimeBookingStatusId.Add(i, 1);
				}
			
			}
			Statuses.TimeBookingStatusId = Statuses.TimeBookingStatusId
								.OrderBy(x => x.Value)
								.ToDictionary(x => x.Key, x => x.Value);

			return Statuses;

			#region MyRegion

			//var allTimeRanges = Enumerable.Range(0, 24)
			//.Select(hour => currentDate.AddHours(hour))
			//.ToList();

			//var filteredAndSortedStatus = status
			//	.Where(item => item.TimeDiapazonId >= currentDate && item.TimeDiapazonId < currentDate.AddDays(1))
			//	.OrderBy(item => item.TimeDiapazonId)
			//	.ToList();

			//var mergedList = allTimeRanges
			//.GroupJoin(filteredAndSortedStatus,
			//		   range => range,
			//		   statusItem => statusItem.TimeDiapazonId,
			//		   (range, statuses) => statuses.DefaultIfEmpty(new BroneStatus { Date = range, BookingStatusId = 3 }))
			//.SelectMany(group => group)
			//.ToList();

			//foreach (var item in filteredAndSortedStatus)
			//{
			//	//DateTime
			//	item.TimeDiapazonId
			//}
			#endregion
		}
	}
}
