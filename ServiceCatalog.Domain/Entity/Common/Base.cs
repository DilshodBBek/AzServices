using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.Entity.Common
{
	public class Base
	{
        public int Id { get; set; }
        public int Name { get; set; }
        public int Location { get; set; }
    }
}
