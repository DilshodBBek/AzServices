using Payment.Domain.Model.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entity.CustomEntity
{
	public  class AccountTransaction
	{
		public int AccountNumber { get; set; }
		public TransactionType TransactionType { get; set; }
		public Money Amount { get; set; }
	}
}
