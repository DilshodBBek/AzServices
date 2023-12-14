using AutoMapper;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Services;

public class RoleService : IRoleService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbcontext _dbcontext;
    private readonly IConfiguration _configuration;

    public RoleService(ApplicationDbcontext dbcontext, IConfiguration configuration, IMapper mapper)
    {
        _dbcontext = dbcontext;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<Response<RoleGetDTO>> CreateRole(RoleCreateDTO roleDTO)
    {
        var existingRole = _dbcontext.Roles.FirstOrDefault(x => x.Name == roleDTO.Name);

        if (existingRole != null)
        {
            return new Response<RoleGetDTO>("Role is already created");
        }
        var role = _mapper.Map<Role>(roleDTO);

        await _dbcontext.Roles.AddAsync(role);

        await _dbcontext.SaveChangesAsync();

        var roleGetDTO = _mapper.Map<RoleGetDTO>(role);

        return new Response<RoleGetDTO>(roleGetDTO);
    }



    public async Task<bool> DeleteRole(int id)
    {
        var Role = _dbcontext.Roles.Where(x => x.Id.Equals(id)).FirstOrDefault();
        _dbcontext.Roles.Remove(Role);
        var rows = _dbcontext.SaveChanges();
        if (rows > 0)
        {
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<RoleGetDTO>> GetAllRoles()
    {
        var getall = _dbcontext.Roles.Include(x => x.Permissions);
        var getalldto = _mapper.Map<IEnumerable<RoleGetDTO>>(getall);
        return getalldto;
    }

    public async Task<RoleGetDTO> GetbyidRole(int Roleid)
    {
        var s = _dbcontext.Roles.Select(x => x).Include(x => x.Permissions).Where(x => x.Id.Equals(Roleid)).First();
        var getbyid = _mapper.Map<RoleGetDTO>(s);
        return getbyid;
    }

    public async Task<bool> UpdateRole(RoleGetDTO roleDTO)
    {
        var Role1 = _dbcontext.Roles.Select(x => x).Include(x => x.Permissions).Where(x => x.Name == roleDTO.Name).First();
        if (Role1 != null)
        {
            _dbcontext.Roles.Update(Role1);
            _dbcontext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

}
