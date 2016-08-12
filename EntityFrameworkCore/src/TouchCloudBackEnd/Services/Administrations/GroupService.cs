using System.Collections.Generic;
using System.Linq;
using TouchCloudBackEnd.Entities;
using TouchCloudBackEnd.Entities.Administrations;

namespace TouchCloudBackEnd.Services.Administrations
{
    public class GroupService : IGroupService
    {
        private TouchcloudDbContext context;

        public GroupService(TouchcloudDbContext context)
        {
            this.context = context;

        }


        public int? Create(Group newGroup)
        {
            var createdGroup = context.Add(newGroup);
            context.SaveChanges();
            if (createdGroup != null)
            {
                return newGroup.IdGroup;
            }
            return 0;
        }


        public IEnumerable<Group> GetAll()
        {
            return context.Groups.ToList();
        }



        public Group GetOne(int? idGroup)
        {
            return context.Groups.FirstOrDefault(result => result.IdGroup == idGroup);
        }



        public Group Update(Group oldGroup, Group newGroup)
        {

            oldGroup.NameGroup = newGroup.NameGroup;
            oldGroup.UserGroups = newGroup.UserGroups;
            oldGroup.DescriptionGroup = newGroup.DescriptionGroup;
            oldGroup.UpdatedAt = newGroup.UpdatedAt;        

            context.SaveChanges();
            return oldGroup;

        }


        public bool Delete(int? idGroup)
        {
            var group = context.Groups.FirstOrDefault(result => result.IdGroup == idGroup);
            context.Remove(group);
            context.SaveChanges();
            if (group == null)
            {
                return true;
            }
            return false;

        }
    }
}
