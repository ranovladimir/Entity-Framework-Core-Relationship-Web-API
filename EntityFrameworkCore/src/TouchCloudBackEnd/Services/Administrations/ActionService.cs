using System.Collections.Generic;
using System.Linq;
using TouchCloudBackEnd.Entities;
using TouchCloudBackEnd.Entities.Administrations;

namespace TouchCloudBackEnd.Services.Administrations
{
    public class ActionService : IActionService
    {
        private TouchcloudDbContext context;

        public ActionService(TouchcloudDbContext context)
        {
            this.context = context;

        }


        public int? Create(Action newAction)
        {
            var createdAction = context.Add(newAction);
            context.SaveChanges();
            if (createdAction != null)
            {
                return newAction.IdAction;
            }
            return 0;
        }


        public IEnumerable<Action> GetAll()
        {
            return context.Actions.ToList();
        }



        public Action GetOne(int? idAction)
        {
            return context.Actions.FirstOrDefault(result => result.IdAction == idAction);
        }



        public Action Update(Action oldAction, Action newAction)
        {

            oldAction.NameAction = newAction.NameAction;
            oldAction.CreatedAt = newAction.CreatedAt;
            oldAction.UpdatedAt = newAction.UpdatedAt;
            oldAction.ActionGroups = newAction.ActionGroups;

            context.SaveChanges();
            return oldAction;

        }


        public bool Delete(int? idAction)
        {
            var action = context.Actions.FirstOrDefault(result => result.IdAction == idAction);
            context.Remove(action);
            context.SaveChanges();
            if (action == null)
            {
                return true;
            }
            return false;

        }
    }
}
