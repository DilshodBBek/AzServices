using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class GetUsersDTO
    {   public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string phone { get; set; }
        public int? Regionid { get; set; }
        public int? Districtid { get; set; }
    }
}
