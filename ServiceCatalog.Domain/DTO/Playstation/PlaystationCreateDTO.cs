using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.DTO.Playstation
{
    public class PlaystationCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        
        //Немного информации о себе
        public string Descryption { get; set; } = string.Empty;

        //Цена и за сколько времени
        public ICollection<(decimal, string)> Price { get; set; } = new List<(decimal, string)>();

        //Время открытия и закрытия
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }

        public int UserId { get; set; }
    }
}
