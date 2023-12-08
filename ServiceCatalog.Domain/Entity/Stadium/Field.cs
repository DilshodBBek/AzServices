using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.Entity.Stadium
{
	public class Field:ICategory
	{
		public int CategoryId { get; set; } = 1;
		public int Id { get; set; }
        public string Name { get; set; }
		public string Address { get; set; }
		public string Size { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public byte[] ImageData { get; set; }

		// TimeSpan.FromHours(10) + TimeSpan.FromMinutes(30);
		public TimeSpan OpeningTime { get; set; }
		public TimeSpan ClosingTime { get; set; }
		
		//bronda bu boladi
		//public List<bool> IsAvailable { get; set; }

	}
}
