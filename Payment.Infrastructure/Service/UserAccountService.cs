using Microsoft.EntityFrameworkCore;
using Payment.Aplication.Repository;
using Payment.Aplication.Service;
using Payment.Domain.Dto;
using Payment.Domain.Entity;
using Payment.Infrastructure.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Service
{

	public class UserAccountService : IUserAccountService 

	{
		private readonly  PaymentDbContext _paymentDb;

		public UserAccountService(PaymentDbContext paymentDb)
		{
			_paymentDb = paymentDb;
		}

		public  async Task<UserAccount> CreateAsync(UserAccountDto user)
		{
			var result = new UserAccountDto()
			{

				UserId = user.UserId,
				CardNamber = user.CardNamber,
				CardValidData = user.CardValidData,
				TotalBalance = user.TotalBalance,
				UserTransoctionids = user.UserTransoctionids.Select(x => x).ToList(),
			};

			_paymentDb.Add(user);
			await _paymentDb.SaveChangesAsync();
			return new();
		}

		public async Task<IEnumerable<UserAccount>> GetAllAsync()
		{
			return await   _paymentDb.Users.ToListAsync();
		}

		public async  Task<UserAccount> GetByIdAsync(int id)
		{
			UserAccount? entity = await _paymentDb.Users.FindAsync(id);
			return entity;
		}
	}
}
