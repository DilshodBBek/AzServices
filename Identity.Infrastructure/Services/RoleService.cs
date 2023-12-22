using Identity.Domain.Entities;
using Identity.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Services
{
    public class RoleService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<Role> _userManager;
        private readonly ApplicationDbcontext _dbContext;

        public RoleService(RoleManager<Role> roleManager, ApplicationDbcontext dbContext, UserManager<Role> userManager = null)
        {
            _roleManager = roleManager;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public List<RoleGetDTO> GetAllRoles()
        {
            List<RoleGetDTO> roles = _dbContext.Roles
                .Include(x => x.Permissions)
                .Select(x => new RoleGetDTO
                {
                    Permissionids = x.Permissions.Select(x => x.id).ToList(),
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return roles;
        }

        public async Task<RoleGetDTO> GetRoleById(int roleId)
        {
            var role = await _dbContext.Roles
                .Include(x => x.Permissions)
                .Where(x => x.Id.Equals(roleId))
                .Select(x => new RoleGetDTO
                {
                    Permissionids = x.Permissions.Select(x => x.id).ToList(),
                    Id = x.Id,
                    Name = x.Name
                })
                .FirstOrDefaultAsync();

            return role;
        }

        public async Task<IActionResult> CreateRole(RoleCreateDTO roleCreateDTO)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleCreateDTO.Name);
            if (roleExists)
            {
                return new BadRequestObjectResult("Role with this name already exists");
            }

            var role = new Role
            {
                Name = roleCreateDTO.Name,
                NormalizedName = roleCreateDTO.Name.ToUpperInvariant(),
                Permissions = roleCreateDTO.Permissionids?.Select(permissionId => new permission
                {
                    id = permissionId,
                    name = roleCreateDTO.Name,
                }).ToList(),
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                if (roleCreateDTO.Permissionids != null)
                {
                    foreach (var permissionId in roleCreateDTO.Permissionids)
                    {
                        var permission = await _dbContext.Permissions.FindAsync(permissionId);
                        if (permission != null)
                        {
                            await _roleManager.AddClaimAsync(role, new Claim("permission", permission.name));
                        }
                    }
                }

                return new OkObjectResult($"Role {role.Name} created successfully");
            }

            return new BadRequestObjectResult("Error creating role");
        }

        public async Task<IActionResult> UpdateRole(UpdateRoleDTO updateRoleDTO)
        {
            var role = await _roleManager.Roles.Include(x => x.Permissions).FirstOrDefaultAsync(x => x.Id.Equals(updateRoleDTO.roleId));
            if (role == null)
            {
                return new NotFoundObjectResult($"Role with ID {updateRoleDTO.roleId} not found");
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
                    var permission = await _dbContext.Permissions.FindAsync(permissionId);
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
                await _dbContext.SaveChangesAsync();
                return new OkObjectResult($"Role with ID {updateRoleDTO.roleId} updated successfully");
            }

            return new BadRequestObjectResult("Error updating role");
        }

        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return new NotFoundObjectResult($"Role with ID {roleId} not found");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return new OkObjectResult($"Role with ID {roleId} deleted successfully");
            }

            return new BadRequestObjectResult("Error deleting role");
        }
    }
}
