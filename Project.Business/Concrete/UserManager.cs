using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null, List<Expression<Func<User, object>>> includes = null)
        {
            return _userDal.GetAll(filter,includes);
        }

        public User Get(Expression<Func<User, bool>> filter, List<Expression<Func<User, object>>> includes = null)
        {
            return _userDal.Get(filter,includes);
        }
    }
}
