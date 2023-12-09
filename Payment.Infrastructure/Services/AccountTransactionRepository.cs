using Braintree;
using Payment.Aplication.Interface;
using Payment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Services
{
	public class AccountTransactionRepository  // : IAccountTransactionRepository

	{
		//public async Task Create(AccountTransactionEntity accountTransactionEntity, AccountSummaryEntity accountSummaryEntity)
		//{
		//	AccountTransactionEntity.Add(accountTransactionEntity);
		//	_accountSummaryEntity.Update(accountSummaryEntity);

		//	bool isSaved = false;

		//	while (!isSaved)
		//	{
		//		try
		//		{
		//			await _dbContext.SaveChangesAsync();
		//			isSaved = true;
		//		}
		//		catch (DbUpdateConcurrencyException ex)
		//		{
		//			foreach (var entry in ex.Entries)
		//			{
		//				if (entry.Entity is AccountSummaryEntity)
		//				{
		//					var databaseValues = entry.GetDatabaseValues();

		//					if (databaseValues != null)
		//					{
		//						entry.OriginalValues.SetValues(databaseValues);
		//						CalculateNewBalance();

		//						void CalculateNewBalance()
		//						{
		//							var balance = (decimal)entry.OriginalValues["Balance"];
		//							var amount = accountTransactionEntity.Amount;

		//							if (accountTransactionEntity.TransactionType == TransactionType.Deposit.ToString())
		//							{
		//								accountSummaryEntity.Balance =
		//								balance += amount;
		//							}
		//							else if (accountTransactionEntity.TransactionType == TransactionType.Withdrawal.ToString())
		//							{
		//								if (amount > balance)
		//									throw new InsufficientBalanceException();

		//								accountSummaryEntity.Balance =
		//								balance -= amount;
		//							}
		//						}
		//					}
		//					else
		//					{
		//						throw new NotSupportedException();
		//					}
		//				}
		//			}
		//		}
		//	}
		//}
	} 
}
