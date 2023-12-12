using ServiceCatalog.Domain.Entity.Playstation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.Entity.Common
{
	public class BookingBase<T>
	{
		public int Id { get; set; }
		public DateTime BroneTime { get; set; }
		public int Duration { get; set; }
		public string BronePhoneNumber { get; set; }
		//1=Waiting
		//2=Paid
		//3=free
		public int ServiceId { get; set; }
		public T Service { get; set; }
	}
}
