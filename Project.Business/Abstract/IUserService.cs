using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        User GetById(int id);
        List<User> GetAll();
    }
}
