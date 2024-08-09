using Project.Core.DataAccess.EntityFramework;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Project.DataAccess.Concrete.EntityFramework
{
    public class EfWatchedFilmDal : EfEntityRepository<WatchedFilm>, IWatchedFilmDal
    {
        private readonly AppDataContext _context;
        public EfWatchedFilmDal(AppDataContext context) : base(context)
        {
            _context=context;
        }
        public List<Film> GetByUserId(int userId)
        {
            return _context.Set<WatchedFilm>()
                .Where(wf => wf.UserId == userId)
                .Include(wf => wf.Film)
                .Select(wf => wf.Film)
                .ToList();
        }
    }
}
