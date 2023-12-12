using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Enititys
{
	public  class UserAccount 
	{
		 public int  Id { get; set; }
		public string CardNamber { get; set; }
		public string CardValidData { get; set; }
		public string TotalBalance { get; set; }
	    public   ICollection<UserTransoction> UserTransoctions { get; set; }
	}
}
