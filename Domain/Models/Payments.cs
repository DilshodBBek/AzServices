using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Models
{
    public class Payments
    {
      
        public string PaymentsId { get; set; }

        public string BookingOrderId { get; set; }

        public decimal Price { get; set; }

        public string UserId { get; set; }


        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
