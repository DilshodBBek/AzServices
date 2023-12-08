using ServiceCatalog.Domain.Entity.Common;
using ServiceCatalog.Domain.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCatalog.Domain.Entity.Playstation
{
    public class PlaystationArea:Base
    {
        public ICollection<string> GameNames { get; set; } = new List<string>();
        public int CategoryId { get; } = 1;
    }
}
