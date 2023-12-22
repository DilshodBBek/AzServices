using Identity.Domain.Entities;
using Identity.Domain.Models;
using Identity.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
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
        private readonly RoleService _roleService;
        public RoleController( RoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet("GetAllRoles")]
        [AuthefrationAttributeFilter("GetAllRoles")]
        public  IActionResult GetAllRoles()
        {
            var roles = _roleService.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("GetRoleById")]
        public async Task<IActionResult> GetRoleById(int roleId)
        {
            var role = await _roleService.GetRoleById(roleId);
            return Ok(role);
        }
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(RoleCreateDTO roleCreateDTO)
        {
            var result = await _roleService.CreateRole(roleCreateDTO);
            return Ok(result);
        }





        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole(UpdateRoleDTO updateRoleDTO)
        {
            var result = await _roleService.UpdateRole(updateRoleDTO);
            return Ok(result);
        }


        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var result = await _roleService.DeleteRole(roleId);
            return Ok(result);
        }
    }
}
