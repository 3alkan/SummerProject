using System.Linq.Expressions;
using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;

namespace Project.Business.Concrete{
    public class WillWatchedFilmManager : IWillWatchedFilmService
    {
        private readonly IWillWatchedFilmDal _willWatchedFilmDal;

        public WillWatchedFilmManager(IWillWatchedFilmDal willWatchedFilmDal)
        {
            _willWatchedFilmDal = willWatchedFilmDal;
        }

        public void Add(WillWatchedFilm willWatchedFilm)
        {
            _willWatchedFilmDal.Add(willWatchedFilm);
        }

        public void Delete(WillWatchedFilm willWatchedFilm)
        {
            _willWatchedFilmDal.Delete(willWatchedFilm);
        }

        public List<WillWatchedFilm> GetAll(Expression<Func<WillWatchedFilm, bool>> filter = null, List<Expression<Func<WillWatchedFilm, object>>> includes = null)
        {
            return _willWatchedFilmDal.GetAll(filter,includes);
        }

        public WillWatchedFilm Get(Expression<Func<WillWatchedFilm, bool>> filter, List<Expression<Func<WillWatchedFilm, object>>> includes = null)
        {
            return _willWatchedFilmDal.Get(filter,includes);
        }

        public List<Film> GetByUserId(int userId)
        {
            return _willWatchedFilmDal.GetByUserId(userId);
        }

        public void Update(WillWatchedFilm willWatchedFilm)
        {
            _willWatchedFilmDal.Update(willWatchedFilm);
        }
    }
}