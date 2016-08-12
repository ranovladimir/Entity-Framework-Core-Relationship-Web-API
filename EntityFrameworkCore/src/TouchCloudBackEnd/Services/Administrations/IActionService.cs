using System.Collections.Generic;
using TouchCloudBackEnd.Entities.Administrations;


namespace TouchCloudBackEnd.Services.Administrations
{
    public interface IActionService
    {
        int? Create(Action newAction);
        IEnumerable<Action> GetAll();
        Action GetOne(int? idAction);
        Action Update(Action oldAction, Action newAction);
        bool Delete(int? idAction);
    }
}

