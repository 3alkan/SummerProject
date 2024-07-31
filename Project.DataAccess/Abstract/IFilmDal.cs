using Project.Entities.Concrete;
using Project.Core.DataAccess;

namespace Project.DataAccess.Abstract
{
    public interface IFilmDal : IEntityRepository<Film>
    {
    }
}
