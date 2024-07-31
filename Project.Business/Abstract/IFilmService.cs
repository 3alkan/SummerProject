using Project.Entities.Concrete;
using System.Collections.Generic;

namespace Project.Business.Abstract
{
    public interface IFilmService
    {
        void Add(Film film);
        void Update(Film film);
        void Delete(Film film);
        Film GetById(int id);
        List<Film> GetAll();
    }
}
