using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiveDataAccess.Core.IRepositories
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T item);
        void AddRange(IEnumerable<T> items);

        void Remove(T item);
        void RemoveRange(IEnumerable<T> items);
    }
}
