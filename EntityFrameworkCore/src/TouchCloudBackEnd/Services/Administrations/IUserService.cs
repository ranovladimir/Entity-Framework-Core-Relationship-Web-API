using System.Collections.Generic;
using TouchCloudBackEnd.Entities.Administrations;


namespace TouchCloudBackEnd.Services.Administrations
{
    public interface IUserService
    {
        int Create(User newUser);
        IEnumerable<User> GetAll();
        User GetOne(int idUser);
        User Update(User oldUser, User newUser);
        bool Delete(int idUser);
    }
}
