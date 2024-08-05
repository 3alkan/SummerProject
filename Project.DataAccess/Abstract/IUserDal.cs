using Project.Core.DataAccess;
using Project.Entities.Concrete;

namespace Project.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}