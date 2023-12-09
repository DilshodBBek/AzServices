using ServiceCatalog.Domain.Entity.Common;
using ServiceCatalog.Domain.Entity.Stadium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.Entity
{
	public class Booking
	{
		public int Id { get; set; }
		public DateTime BroneTime { get; set; }
		public TimeSpan Duration { get; set; }

		

		// Связь с категорией поля через общий интерфейс
		public int ServiceId { get; set; }
		public Base Service { get; set; }

		public int CategoryId { get; set; }

	}
}
