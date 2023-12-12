using ServiceCatalog.Domain.Entity.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.Entity.Common
{
	public class Base
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Location { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public ICollection<FileContent> PhotoOrVideo { get; set; } 

		//Немного информации о себе
		public string Descryption { get; set; } = string.Empty;

        //Время открытия и закрытия
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }

		public int UserId { get; set; }

    }
}
