using System.Collections.Generic;
using TouchCloudBackEnd.Entities.Administrations;

namespace TouchCloudBackEnd.Services.Administrations
{
    public interface IRoleUserService
    {
        int? Create(RoleUser newRoleUser);
        IEnumerable<RoleUser> GetAll();
        RoleUser GetOne(int? idRoleUser);
        RoleUser Update(RoleUser oldRoleUser, RoleUser newRoleUser);
        bool Delete(int? idRoleUser);
    }
}
