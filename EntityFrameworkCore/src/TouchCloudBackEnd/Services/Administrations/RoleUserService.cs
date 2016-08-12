using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TouchCloudBackEnd.Entities;
using TouchCloudBackEnd.Entities.Administrations;
using System;

namespace TouchCloudBackEnd.Services.Administrations
{
    public class RoleUserService : IRoleUserService
    {
        private TouchcloudDbContext context;

        public RoleUserService(TouchcloudDbContext context)
        {
            this.context = context;

        }


        public int? Create(RoleUser newRoleUser)
        {
            var createdRoleUser = context.Add(newRoleUser);
            context.SaveChanges();
            if (createdRoleUser != null)
            {
                return newRoleUser.IdRoleUser;
            }
            return 0;
        }


        public IEnumerable<RoleUser> GetAll()
        {
            return context.RoleUsers.ToList();
        }



        public RoleUser GetOne(int? idRoleUser)
        {
            return context.RoleUsers.FirstOrDefault(result => result.IdRoleUser == idRoleUser);
        }



        public RoleUser Update(RoleUser oldRoleUser, RoleUser newRoleUser)
        {

            oldRoleUser.NumberRoleUser = newRoleUser.NumberRoleUser; 
            oldRoleUser.NameRoleUser = newRoleUser.NameRoleUser;
            oldRoleUser.UpdatedAt = newRoleUser.UpdatedAt;

            context.SaveChanges();
            return oldRoleUser;

        }


        public bool Delete(int? idRoleUser)
        {
            var roleUser = context.RoleUsers.FirstOrDefault(result => result.IdRoleUser == idRoleUser);
            context.Remove(roleUser);
            context.SaveChanges();
            if (roleUser == null)
            {
                return true;
            }
            return false;

        }
    }
}
