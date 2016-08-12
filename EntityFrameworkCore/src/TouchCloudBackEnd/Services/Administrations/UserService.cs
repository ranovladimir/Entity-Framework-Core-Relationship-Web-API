using System.Collections.Generic;
using System.Linq;
using TouchCloudBackEnd.Entities;
using TouchCloudBackEnd.Entities.Administrations;

namespace TouchCloudBackEnd.Services.Administrations
{

    public class UserService : IUserService
    {
        private TouchcloudDbContext context;
 
        public UserService(TouchcloudDbContext context)
        {
            this.context = context;

        }

        public int Create(User newUser)
        {
           var createdUser = context.Add(newUser);
            context.SaveChanges();
            if (createdUser!=null)
            {
                return newUser.IdUser;
            }
            return 0;
        }


        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();

        }



        public User GetOne(int idUser)
        {
            return context.Users.FirstOrDefault(result => result.IdUser == idUser);
        }



       public User Update(User oldUser, User newUser)
        {


            oldUser.PseudoUser = newUser.PseudoUser;
            oldUser.PasswordUser = newUser.PasswordUser;
            oldUser.EmailUser = newUser.EmailUser;
            oldUser.BirthdateUser = newUser.BirthdateUser;
            oldUser.RoleUser = newUser.RoleUser;
            oldUser.HiddenInfos = newUser.HiddenInfos;
            oldUser.UpdatedAt = newUser.UpdatedAt;
            oldUser.CreatedAt = newUser.CreatedAt;
            oldUser.RoleUser_Id = newUser.RoleUser_Id;
            //context.Update(oldUser);      //can be add, but the update can be done without
            context.SaveChanges();
            return oldUser;

        }


        public bool Delete(int idUser)
        {
            var user = context.Users.FirstOrDefault(result => result.IdUser == idUser);
            context.Remove(user);
            context.SaveChanges();
            if (user == null)
            {
                return true;
            }
            return false;

        }
    }
}
