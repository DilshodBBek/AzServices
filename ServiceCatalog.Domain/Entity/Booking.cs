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
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		// Связь с полем, которое забронировано
		public int FieldId { get; set; }
		public Field Field { get; set; }

		// Связь с категорией поля через общий интерфейс
		public int FieldCategoryId { get; set; }
		public Base FieldCategory { get; set; }
	}
}
