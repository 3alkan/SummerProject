using Project.Entities.Concrete;
using Project.Core.DataAccess;

namespace Project.DataAccess.Abstract
{
    public interface IWatchedFilmDal : IEntityRepository<WatchedFilm>
    {
        List<Film> GetByUserId(int userId);
    }
}
