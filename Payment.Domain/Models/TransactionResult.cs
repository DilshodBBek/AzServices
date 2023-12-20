using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Models
{
	public  class TransactionResult
	{
		public int AccountNumber { get; set; }
		public bool IsSuccessful { get; set; }
		public Money Balance { get; set; }
		public string Message { get; set; }
	}
}
