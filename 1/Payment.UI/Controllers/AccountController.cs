using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Aplication.Service;
using Payment.Domain.Dto;
using Payment.Domain.Entity;

namespace Payment.UI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IUserAccountService _userAccountService;

		public AccountController(IUserAccountService userAccountService) =>
			_userAccountService = userAccountService;


		[HttpGet]
		public async Task<IEnumerable<UserAccount>> GetAllAsync()
		{

			var result = await _userAccountService.GetAllAsync();
			return result;
		}
		[HttpGet]
		public async Task<UserAccount> GetByIdAsync(int Id)
		{

			var resul = await _userAccountService.GetByIdAsync(Id);
			return resul;
		}

		[HttpPost]
		public async Task<UserAccount> CreateAsync(UserAccountDto user)
		{

			var result = await _userAccountService.CreateAsync(user);

			return result;
		}

	}
}
