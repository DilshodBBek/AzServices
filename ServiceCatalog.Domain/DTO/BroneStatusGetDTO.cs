using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.DTO
{
	public class BroneStatusGetDTO
	{
		public int UnitBaseId { get; set; }
		public DateTime Date { get; set; }
		public Dictionary<int,int> TimeBookingStatusId { get; set; }
	}
}
