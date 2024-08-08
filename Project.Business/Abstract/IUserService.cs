using Project.Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Project.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        User GetById(int id);
        List<User> GetAll(Expression<Func<User, bool>> filter = null);
        User Get(Expression<Func<User, bool>> filter);
    }
}
