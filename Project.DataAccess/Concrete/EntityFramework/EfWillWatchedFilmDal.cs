using Project.Core.DataAccess.EntityFramework;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Project.DataAccess.Concrete.EntityFramework
{
    public class EfWillWatchedFilmDal : EfEntityRepository<WillWatchedFilm>, IWillWatchedFilmDal
    {
        private readonly AppDataContext _context;
        public EfWillWatchedFilmDal(AppDataContext context) : base(context)
        {
            _context = context;
        }

        public List<Film> GetByUserId(int userId)
        {
            return _context.Set<WillWatchedFilm>()
                .Where(wf => wf.UserId == userId)
                .Include(wf => wf.Film)
                .Select(wf => wf.Film)
                .ToList();
        }
    }
}
