using Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public readonly ApplicationDbcontext _dbcontext;
       // permission Permission=new permission();
        private readonly RoleManager<Role> _roleManager;

        public RoleController(RoleManager<Role> roleManager, ApplicationDbcontext dbcontext)
        {
            _roleManager = roleManager;
            _dbcontext = dbcontext;
        }
        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _dbcontext.Roles.Include(x=>x.Permissions).ToList();
            return Ok(roles);
        }

        [HttpGet("GetRoleById")]
        public async Task<IActionResult> GetRoleById(string roleId)
        {
            var role = _dbcontext.Roles.Include(x => x.Permissions).Where(x=>x.Id.Equals(roleId)).ToList();
            if (role == null)
            {
                return NotFound($"Role with ID {roleId} not found");
            }

            return Ok(role);
        }
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName, List<int> permissionIds)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (roleExists)
            {
                return BadRequest("Role with this name already exists");
            }

            var role = new Role { Name = roleName };
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                if (permissionIds != null && permissionIds.Any())
                {
                    foreach (var permissionId in permissionIds)
                    {
                        var permission = await _dbcontext.Permissions.FindAsync(permissionId);
                        if (permission != null)
                        {
                            role.Permissions.Add(new permission 
                            {
                               id=permission.id,
                             });
                        }
                    }

                    await _dbcontext.SaveChangesAsync();
                }

                return Ok($"Role {roleName} created successfully");
            }

            return BadRequest("Error creating role");
        }



        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole(int roleId, string newRoleName, List<int> permissionIds)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null)
            {
                return NotFound($"Role with ID {roleId} not found");
            }

            role.Name = newRoleName;

            // Remove existing permissions
            role.Permissions.Clear();

            if (permissionIds != null && permissionIds.Any())
            {
                foreach (var permissionId in permissionIds)
                {
                    var permission = await _dbcontext.Permissions.FindAsync(permissionId);
                    if (permission != null)
                    {
                        role.Permissions.Add(new permission
                        {
                            id = permission.id,
                        });
                    }
                }

                await _dbcontext.SaveChangesAsync();
            }


            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return Ok($"Role with ID {roleId} updated successfully");
            }

            return BadRequest("Error updating role");
        }

        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound($"Role with ID {roleId} not found");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return Ok($"Role with ID {roleId} deleted successfully");
            }

            return BadRequest("Error deleting role");
        }
    }
}
