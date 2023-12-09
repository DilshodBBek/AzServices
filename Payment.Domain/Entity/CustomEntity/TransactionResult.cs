
using Payment.Domain.Model.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entity.CustomEntity
{
	public  class TransactionResult
	{
		public int AccountNumber { get; set; }
		public bool IsSuccessful { get; set; }
		public Money Balance { get; set; }
		public string Message { get; set; }
	}
}
