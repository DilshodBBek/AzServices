using Payment.Aplication.Repository;
using Payment.Domain.Dto;
using Payment.Domain.Entity;

namespace Payment.Aplication.Service
{
	public interface IUserTransoctionService : IRepository<UserTransoction>
	{
		Task<IEnumerable<UserTransoction>> GetAllAsync();
		Task<UserTransoction> GetByIdAsync(int id);
		Task<UserTransoction> CreateAysnc(UserTransoctionDto transoction);
	}

}
