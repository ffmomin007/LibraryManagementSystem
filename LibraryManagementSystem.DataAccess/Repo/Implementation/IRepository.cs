using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Repo.Implementation
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Get(Expression<Func<T,bool>> filter);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Add(T entity);
    }
}
