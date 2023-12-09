using Microsoft.EntityFrameworkCore;
using Payment.Domain.Entity;
using Payment.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure
{
	public  class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext() { }
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
	  : base(options)
		{ }
		public  DbSet<AccountSummaryEntity> AccountSummaryEntity { get; set; } 
		public  DbSet<AccountTransactionEntity> AccountTransactionEntity { get; set; }

		

	}
}
