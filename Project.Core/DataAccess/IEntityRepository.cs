using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Project.Core.Entities;

namespace Project.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        List<T> GetAll(Expression<Func<T, bool>> filter = null, List<Expression<Func<T, object>>> includes = null);
        T Get(Expression<Func<T, bool>> filter = null, List<Expression<Func<T, object>>> includes = null);
    }
}
