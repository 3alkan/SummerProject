using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Project.Core.DataAccess;
using Project.Core.Entities;

namespace Project.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _entities;

        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? _entities.ToList()
                : _entities.Where(filter).ToList();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _entities.SingleOrDefault(filter);
        }

    }
}
