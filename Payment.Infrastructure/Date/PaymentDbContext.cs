using Microsoft.EntityFrameworkCore;
using Payment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Date
{
	public  class PaymentDbContext : DbContext
	{
		public PaymentDbContext(DbContextOptions<PaymentDbContext> options ) : base( options )
		{

		}
		public DbSet<UserAccount> Users { get; set; }
		public DbSet<UserTransoction> Transactions { get; set; }

	}
}
