using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
   public class User
    {
        public int Id { get; set; }

        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Faqat harflar qabul qilinadi")]
        public string FullName { get; set; }
       
        [RegularExpression(@"^\+998\d{9}$")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@".+@gmail\.com$")]
        public string Email { get; set; }

       
    }
}
