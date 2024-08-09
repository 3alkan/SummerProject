using Project.Core.DataAccess.EntityFramework;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Project.DataAccess.Concrete.EntityFramework
{
    public class EfFilmDal : EfEntityRepository<Film>, IFilmDal
    {
        public EfFilmDal(AppDataContext context) : base(context)
        {
         
        }
    }
}
