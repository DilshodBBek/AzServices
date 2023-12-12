using ServiceCatalog.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.Entity.Stadium
{
	public class Field:UnitBase
	{
		public Stadium Stadium { get; set; }
	}
}
