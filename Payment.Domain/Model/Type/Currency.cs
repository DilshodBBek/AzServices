using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Model.Type
{
	public  enum Currency
	{
		Unknown = 0,

		[Description("United States dollar")]
		USD = 840,

		[Description("Pound sterling")]
		GBP = 826,

		[Description("Euro")]
		EUR = 978,

		[Description("Indian rupee")]
		INR = 356
	}
}
