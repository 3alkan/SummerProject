using Project.Core.DataAccess.EntityFramework;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;

namespace Project.DataAccess.Concrete.EntityFramework
{
    public class EfFilmDal : EfEntityRepositoryBase<Film>, IFilmDal
    {
        public EfFilmDal(AppDataContext context) : base(context)
        {
        }
    }
}
