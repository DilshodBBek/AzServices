using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.Entity
{
	public interface ICategory
	{
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public int Location { get; set; }
        public ICollection<byte[]> PhotoOrVideo { get; set; } = new List<byte[]>();

        //Немного информации о себе
        public string Descryption { get; set; } = string.Empty;

        //Цена и за сколько времени
        public ICollection<(decimal,string)> Price { get; set; } = new List<(decimal, string)>();


        //Время открытия и закрытия
        public TimeOnly OpenTime { get; set; }
        public TimeOnly CloseTime { get; set; }
    }
}
