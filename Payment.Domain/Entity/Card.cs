using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entity
{
    public  class Card
    {
        public int CardId { get; set; }
        [RegularExpression(@"^\d{16}$")]
        public string CardNumber {  get; set; } 

        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Not a valid expiration date.")]
        //salom laziz qondaye
        public string ExpirationDate { get; set; } 
    }
}
