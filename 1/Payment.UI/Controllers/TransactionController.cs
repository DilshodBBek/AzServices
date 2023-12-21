using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Aplication.Service;
using Payment.Domain.Dto;
using Payment.Domain.Entity;

namespace Payment.UI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class TransactionController : ControllerBase
	{
		private readonly IUserTransoctionService _userTransactionService;
		

		public TransactionController(IUserTransoctionService userTransactionService)
		{
			_userTransactionService = userTransactionService;
		
		}

		[HttpGet]
		public async Task<IEnumerable<UserTransoction>> GetAllAsync()
		{
			var result = await _userTransactionService.GetAllAsync();

			return result;
		}
		[HttpGet]
		public async Task<UserTransoction> GetByIdAsync(int Id)
		{

			var resul = await _userTransactionService.GetByIdAsync(Id);
			return resul;
		}

		[HttpPost]
		public async Task<UserTransoction> CreateAsync(UserTransoctionDto user)
		{

			var result = await _userTransactionService.CreateAysnc(user);

			return result;

		}
	}
}
