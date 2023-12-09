using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Configuration
{
	public static  class AccountSummaryEntityConfiguration
	{
		public static void Configure(EntityTypeBuilder<AccountSummaryEntity> entityBuilder)
		{
			entityBuilder.HasKey(t => t.AccountNumber);
			entityBuilder.Property(t => t.Balance).IsConcurrencyToken().IsRequired();
			entityBuilder.Property(t => t.Currency).IsRequired();
		}
	}
}
