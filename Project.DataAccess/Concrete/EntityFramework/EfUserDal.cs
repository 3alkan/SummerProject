using Project.Core.DataAccess.EntityFramework;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;

namespace Project.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepository<User>, IUserDal
    {
        public EfUserDal(AppDataContext context) : base(context)
        {
        }
    }
}
