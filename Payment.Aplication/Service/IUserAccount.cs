namespace Payment.Aplication.Service
{
	public interface IUserAccount
	{
		 Task<UserAccount> Read(int accountNumber);
	}
}
