using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entity
{
	[Table("AccountSummary", Schema = "dbo")]
	public  class AccountSummaryEntity
	{
		[Key]
		public int AccountNumber { get; set; }
		public decimal Balance { get; set; }
		public string Currency { get; set; }
		public ICollection<AccountTransactionEntity> AccountTransactions { get; set; }
	}
}
