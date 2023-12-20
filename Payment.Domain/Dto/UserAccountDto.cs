using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Dto
{
	public  class UserAccountDto
	{

		public string UserId { get; set; }
		public string CardNamber { get; set; }
		public string CardValidData { get; set; }
		public string TotalBalance { get; set; }
		public virtual ICollection<int> UserTransoctionids { get; set; }
	}
}
