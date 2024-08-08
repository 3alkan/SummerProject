using Project.Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Project.Business.Abstract
{
    public interface IWillWatchedFilmService
    {
        void Add(WillWatchedFilm willWatchedFilm);
        void Update(WillWatchedFilm willWatchedFilm);
        void Delete(WillWatchedFilm willWatchedFilm);
        List<Film> GetByUserId(int userId);
        List<WillWatchedFilm> GetAll(Expression<Func<WillWatchedFilm, bool>> filter = null);
        WillWatchedFilm Get(Expression<Func<WillWatchedFilm, bool>> filter);
    }
}
