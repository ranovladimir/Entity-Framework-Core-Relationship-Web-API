using System.Collections.Generic;
using TouchCloudBackEnd.Entities.Administrations;

namespace TouchCloudBackEnd.Services.Administrations
{
    public interface IGroupService
    {
        int? Create(Group newGroup);
        IEnumerable<Group> GetAll();
        Group GetOne(int? idGroup);
        Group Update(Group oldGroup, Group newGroup);
        bool Delete(int? idGroup);
    }
}
