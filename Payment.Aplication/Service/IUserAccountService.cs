using Payment.Aplication.Repository;
using Payment.Domain.Dto;
using Payment.Domain.Entity;

namespace Payment.Aplication.Service
{
	public interface IUserAccountService : IRepository<UserAccount>
	{
		Task<IEnumerable<UserAccount>> GetAllAsync();
		Task<UserAccount> GetByIdAsync(int id);
		Task<UserAccount> CreateAsync(UserAccountDto user);
	}
}
