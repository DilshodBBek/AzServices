using System.ComponentModel.DataAnnotations;

namespace Payment.Domain.Entity;

public class Card
{
    public int CardId { get; set; }
    [RegularExpression(@"^\d{16}$")]
    public string CardNumber { get; set; }

        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Not a valid expiration date.")]
       
        public string ExpirationDate { get; set; } 
}
