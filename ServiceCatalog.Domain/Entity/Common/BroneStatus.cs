using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.Entity.Common
{
	public class BroneStatus
	{
        public int Id { get; set; }
		//Sp
		//1=Waiting
		//2=Paid
		//3=free
		public int BookingStatusId { get; set; }
        //Sp  1soatdan buladi
        public DateTime TimeDiapazonId { get; set; }

        public int UnitBaseId { get; set; }
        public UnitBase UnitBase { get; set; }

    }
}
