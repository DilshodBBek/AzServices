using ServiceCatalog.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.Entity.Stadium
{
	public class Field :Base
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Location { get; set; }
		public ICollection<byte[]> PhotoOrVideo { get; set; }
		public string Descryption { get; set; }
		public ICollection<(decimal, string)> Price { get; set; }
		public TimeOnly OpenTime { get; set; }
		public TimeOnly CloseTime { get; set; }
	}
}
