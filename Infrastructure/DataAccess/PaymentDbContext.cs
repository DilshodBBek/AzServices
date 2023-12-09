using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO.Pipes;

namespace Payment.Infrastructure.DataAccess
{
    public class PaymentDbContext : DbContext
    {


        public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
                 : base(options)
        {

        }

        public DbSet<Payments> Payments { get; set; }



    }
}


   

