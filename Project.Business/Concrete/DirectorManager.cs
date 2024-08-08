using System.Linq.Expressions;
using Project.Business.Abstract;
using Project.DataAccess.Abstract;
using Project.Entities.Concrete;

namespace Project.Business.Concrete{
    public class DirectorManager : IDirectorService
    {
        private readonly IDirectorDal _directorDal;

        public DirectorManager(IDirectorDal directorDal)
        {
            _directorDal = directorDal;
        }

        public void Add(Director director)
        {
            _directorDal.Add(director);
        }

        public void Delete(Director director)
        {
            _directorDal.Delete(director);
        }

        public Director Get(Expression<Func<Director, bool>> filter)
        {
            return _directorDal.Get(filter);
        }

        public List<Director> GetAll(Expression<Func<Director, bool>> filter = null)
        {
            return _directorDal.GetAll(filter);
        }

        public Director GetById(int id)
        {
            return _directorDal.GetById(id);
        }

        public void Update(Director director)
        {
            _directorDal.Update(director);
        }
    }
}