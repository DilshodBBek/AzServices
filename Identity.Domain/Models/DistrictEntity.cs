using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class DistrictEntity
    {
        public int DistrictId { get; set; }
        public string? DistrictNameUz { get; set; }
        public string? DistrictNameRu { get; set; }
        public string? DistrictNameEn { get; set; }
    }
}
