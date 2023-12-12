using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public class Role:IdentityRole<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<ApplicationUser>? Users { get; set; }
        public virtual ICollection<permission>? Permissions { get; set; }
    }
}
