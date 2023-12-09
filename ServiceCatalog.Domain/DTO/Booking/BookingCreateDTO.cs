using ServiceCatalog.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.DTO.Booking
{
	public class BookingCreateDTO
	{
		public DateTime BroneTime { get; set; }
		public TimeSpan Duration { get; set; }
		public string BronePhoneNumber { get; set; }

		// Связь с категорией поля через общий интерфейс
		public int ServiceId { get; set; }
		public Base Service { get; set; }
	}
}
