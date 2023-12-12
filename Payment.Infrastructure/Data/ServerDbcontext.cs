using Microsoft.EntityFrameworkCore;
using Payment.Domain.Enititys;

namespace Payment.Infrastructure.Data
{
	public class ServerDbcontext : DbContext
	{
		public ServerDbcontext() { }
		public ServerDbcontext(DbContextOptions<ServerDbcontext> options) : base(options) { }
		public DbSet<UserAccount> Users { get; set; }
		public DbSet<UserTransoction> Transactions { get; set; }

	}
}
