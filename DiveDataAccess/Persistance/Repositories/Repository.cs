using DiveDataAccess.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;

namespace DiveDataAccess.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            _context.Set<T>().AddRange(items);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Remove(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            _context.Set<T>().RemoveRange(items);
        }
    }
}