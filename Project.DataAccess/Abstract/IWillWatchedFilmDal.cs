using Project.Entities.Concrete;
using Project.Core.DataAccess;

namespace Project.DataAccess.Abstract
{
    public interface IWillWatchedFilmDal : IEntityRepository<WillWatchedFilm>
    {
        List<Film> GetByUserId(int userId);
    }
}
