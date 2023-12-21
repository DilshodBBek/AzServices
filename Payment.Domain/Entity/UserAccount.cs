using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entity
{
	public  class UserAccount
	{
		[Key]
		public int Id { get; set; }
		public string UserId { get; set; }
		public string CardNamber { get; set; }
		public string CardValidData { get; set; }
		public string TotalBalance { get; set; }

		//[JsonIgnore]
		public virtual ICollection<UserTransoction> UserTransoctions { get; set; }
	}
}
