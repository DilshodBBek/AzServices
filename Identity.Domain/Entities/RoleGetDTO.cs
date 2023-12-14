using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities
{
    public class RoleGetDTO : IdentityRole<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<int>? Permissionids { get; set; }
    }
}
