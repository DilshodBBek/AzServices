using Payment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Aplication.Interface
{
	public  interface IAccountSummaryRepository
	{
		Task<AccountSummaryEntity> Read(int accountNumber);
	}
}
