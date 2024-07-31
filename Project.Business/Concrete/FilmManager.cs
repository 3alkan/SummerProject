using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.Business.Concrete
{
    public class FilmManager : IFilmService
    {
        private readonly IFilmDal _filmDal;

        public FilmManager(IFilmDal filmDal)
        {
            _filmDal = filmDal;
        }

        public void Add(Film film)
        {
            _filmDal.Add(film);
        }

        public void Update(Film film)
        {
            _filmDal.Update(film);
        }

        public void Delete(Film film)
        {
            _filmDal.Delete(film);
        }

        public Film GetById(int id)
        {
            return _filmDal.GetById(id);
        }

        public List<Film> GetAll()
        {
            return _filmDal.GetAll();
        }
    }
}
