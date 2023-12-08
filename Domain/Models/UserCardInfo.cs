using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
    public class UserCardInfo
    {
        public int Id { get; set; }


        [RegularExpression("@\"^\\d{16}$\"")]
        public string UserCardNumber { get; set; }

        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Not a valid expiration date.")]
        public string ExpirationDate { get; set; }
    }
}
