using System.Linq.Expressions;
using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;

namespace Project.Business.Concrete{
    public class WatchedFilmManager : IWatchedFilmService
    {
        private readonly IWatchedFilmDal _watchedFilmDal;

        public WatchedFilmManager(IWatchedFilmDal watchedFilmDal)
        {
            _watchedFilmDal= watchedFilmDal;
        }

        public void Add(WatchedFilm watchedFilm)
        {
            _watchedFilmDal.Add(watchedFilm);
        }

        public void Delete(WatchedFilm watchedFilm)
        {
            _watchedFilmDal.Delete(watchedFilm);
        }

        public List<WatchedFilm> GetAll(Expression<Func<WatchedFilm, bool>> filter = null, List<Expression<Func<WatchedFilm, object>>> includes = null)
        {
            return _watchedFilmDal.GetAll(filter,includes);
        }

        public WatchedFilm Get(Expression<Func<WatchedFilm, bool>> filter, List<Expression<Func<WatchedFilm, object>>> includes = null)
        {
            return _watchedFilmDal.Get(filter,includes);
        }

        public List<Film> GetByUserId(int userId)
        {
            return _watchedFilmDal.GetByUserId(userId);
        }

        public void Update(WatchedFilm watchedFilm)
        {
            _watchedFilmDal.Update(watchedFilm);
        }
    }
}