using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Dto
{
	public  class UserTransoctionDto
	{
		 
		public double UserAccountId  { get; set; }
		public string SendorId { get; set; }
		public bool Result { get; set; }
		public string Amaunt { get; set; }
		public string CardNumber { get; set; }
		public string PaymentServise { get; set; }
		public DateTime DateTime { get; set; }
		

		public virtual ICollection<int> UserAccountids { get; set; }
	}
}
