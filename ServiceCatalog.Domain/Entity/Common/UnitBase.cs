﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.Entity.Common
{
	public class UnitBase
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public List<BroneStatus> BroneStatuses { get; set; }
	}
}
