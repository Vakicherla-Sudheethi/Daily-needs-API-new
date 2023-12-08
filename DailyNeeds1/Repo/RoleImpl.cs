using System;
using System.Collections.Generic;
using System.Linq;
using DailyNeeds1.DTO;
using DailyNeeds1.Entities;

namespace DailyNeeds1.Repo
{
    public class RoleImpl : IRepo<RoleDTO>
    {
        private DailyNeedsDbContext ctx;

        public RoleImpl(DailyNeedsDbContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(RoleDTO item)
        {
            try
            {
                Role role = new Role
                {
                    RoleName = item.RoleName
                };

                ctx.roles.Add(role);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
         
                return false;
            }
        }

        public bool Delete(int roleId)
        {
            try
            {
                var role = ctx.roles.Find(roleId);
                if (role != null)
                {
                    ctx.roles.Remove(role);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<RoleDTO> GetAll()
        {
            var roles = ctx.roles
                .Select(r => new RoleDTO
                {
                    RoleId = r.RoleId,
                    RoleName = r.RoleName
                })
                .ToList();

            return roles;
        }

        public bool Update(RoleDTO item)
        {
            try
            {
                var role = ctx.roles.Find(item.RoleId);
                if (role != null)
                {
                    role.RoleName = item.RoleName;
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
