using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
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
            List<RoleGetDTO> roles = _dbcontext.Roles
    .Include(x => x.Permissions)
    .Select(x => new RoleGetDTO
    {
       Permissionids=x.Permissions.Select(x=>x.id).ToList(),
       Id=x.Id,
       Name=x.Name
    }).ToList();

            return Ok(roles);
        }

        [HttpGet("GetRoleById")]
        public async Task<IActionResult> GetRoleById(int roleId)
        {
            List<RoleGetDTO> role = _dbcontext.Roles.Include(x => x.Permissions).Select(x => new RoleGetDTO
            {
                Permissionids = x.Permissions.Select(x => x.id).ToList(),
                Id = x.Id,
                Name = x.Name
            }).ToList().Where(x=>x.Id.Equals(roleId)).ToList();
            if (role == null)
            {
                return NotFound($"Role with ID {roleId} not found");
            }

            return Ok(role);
        }
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(RoleCreateDTO roleCreateDTO)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleCreateDTO.Name);
            if (roleExists)
            {
                return BadRequest("Role with this name already exists");
            }

            var role = new Role
            {
                Name = roleCreateDTO.Name,
                NormalizedName = roleCreateDTO.Name.ToUpperInvariant(),
                Permissions = roleCreateDTO.Permissionids?.Select(permissionId => new permission
                {
                    id = permissionId,
                    name=roleCreateDTO.Name,
                    
                }).ToList(),
            };

            _dbcontext.Roles.Attach(role);

            var result = await _dbcontext.SaveChangesAsync();

            if (result > 0)
            {
                if (roleCreateDTO.Permissionids != null)
                {
                    foreach (var permissionId in roleCreateDTO.Permissionids)
                    {
                        var permission = await _dbcontext.Permissions.FindAsync(permissionId);
                        if (permission != null)
                        {
                            await _roleManager.AddClaimAsync(role, new Claim("permission", permission.name));
                        }
                    }
                }

                return Ok($"Role {role.Name} created successfully");
            }

            return BadRequest("Error creating role");
        }





        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole(UpdateRoleDTO updateRoleDTO)
        {
            var role = await _roleManager.Roles.Include(x=>x.Permissions).FirstOrDefaultAsync(x=>x.Id.Equals(updateRoleDTO.roleId));
            if (role == null)
            {
                return NotFound($"Role with ID {updateRoleDTO.roleId} not found");
            }

            if (updateRoleDTO.permissionIds != null)
            {
                // Remove permissions that are no longer selected
                List<permission> permissionsToRemove = role.Permissions.ToList();

                foreach (var permissionToRemove in permissionsToRemove)
                {
                    role.Permissions.ToList().Remove(permissionToRemove);
                }

                // Add new permissions
                foreach (var permissionId in updateRoleDTO.permissionIds)
                {
                    var permission = await _dbcontext.Permissions.FindAsync(permissionId);
                    if (permission != null && !role.Permissions.Contains(permission))
                    {
                        role.Permissions.ToList().Add(permission);
                    }
                }
            }
            role.Name = updateRoleDTO.newRoleName;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                await _dbcontext.SaveChangesAsync();
                return Ok($"Role with ID {updateRoleDTO.roleId} updated successfully");
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
