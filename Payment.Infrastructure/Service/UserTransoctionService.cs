using Microsoft.EntityFrameworkCore;
using Payment.Aplication.Service;
using Payment.Domain.Dto;
using Payment.Domain.Entity;
using Payment.Infrastructure.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Service
{
	public class UserTransoctionService : IUserTransoctionService
	{
		private readonly PaymentDbContext _paymentDb;
		public async  Task<UserTransoction> CreateAysnc(UserTransoctionDto transoction)
		{
			UserTransoction usertransactionEntity = new UserTransoction()
			{
				Result = transoction.Result,
				Amaunt = transoction.Amaunt,
				SendorId = transoction.SendorId,
				CardNumber = transoction.CardNumber,
				UserAccountId = transoction.UserAccountId,
				PaymentServise = transoction.PaymentServise,
				Date = transoction.DateTime = DateTime.UtcNow,
			//	 UserAccounts = transoction.UserAccountids.Select (x=>x).ToList(),


			};
			_paymentDb.Add(usertransactionEntity);
			_paymentDb.SaveChanges();
			return usertransactionEntity;

		}

		public async  Task<IEnumerable<UserTransoction>> GetAllAsync()
		{
			return await _paymentDb.Transactions.ToListAsync();
		}

		public async  Task<UserTransoction> GetByIdAsync(int id)
		{
			UserTransoction? entity = await _paymentDb.Transactions.FindAsync(id);
			return entity;
		}
	}
}
