using Project.Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Project.Business.Abstract
{
    public interface IDirectorService
    {
        void Add(Director director);
        void Update(Director director);
        void Delete(Director director);
        Director GetById(int id);
        List<Director> GetAll(Expression<Func<Director, bool>> filter = null,List<Expression<Func<Director, object>>> includes = null);
        Director Get(Expression<Func<Director, bool>> filter,List<Expression<Func<Director, object>>> includes = null);
    }
}
