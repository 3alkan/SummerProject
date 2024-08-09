using Project.Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Project.Business.Abstract
{
    public interface IWatchedFilmService
    {
        void Add(WatchedFilm watchedFilm);
        void Update(WatchedFilm watchedFilm);
        void Delete(WatchedFilm watchedFilm);
        List<Film> GetByUserId(int userId);
        List<WatchedFilm> GetAll(Expression<Func<WatchedFilm, bool>> filter = null,List<Expression<Func<WatchedFilm, object>>> includes = null);
        WatchedFilm Get(Expression<Func<WatchedFilm, bool>> filter,List<Expression<Func<WatchedFilm, object>>> includes = null);
    }
}
