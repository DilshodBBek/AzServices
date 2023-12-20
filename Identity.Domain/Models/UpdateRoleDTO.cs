using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models
{
    public class UpdateRoleDTO
    {
         public int roleId {  get; set; }
         public string newRoleName { get; set; }
         public IEnumerable<int> permissionIds { get; set; }
    }
}
