using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class RegionEntity
    {
        public int RegionId { get; set; }
        public string? RegionNameUz { get; set; }
        public string? RegionNameRu { get; set; }
        public string? RegionNameEn { get; set; }
    }
}
