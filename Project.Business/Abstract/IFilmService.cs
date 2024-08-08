using Project.Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Project.Business.Abstract
{
    public interface IFilmService
    {
        void Add(Film film);
        void Update(Film film);
        void Delete(Film film);
        Film GetById(int id);
        List<Film> GetAll(Expression<Func<Film, bool>> filter = null);
        Film Get(Expression<Func<Film, bool>> filter);

    }
}
