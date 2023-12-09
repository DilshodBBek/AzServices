using ServiceCatalog.Domain.Entity.Common;
using ServiceCatalog.Domain.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.Entity.Stadium
{
	public class Stadium :Base
	{
		public int CategoryId { get; } = 2;
	}
}
