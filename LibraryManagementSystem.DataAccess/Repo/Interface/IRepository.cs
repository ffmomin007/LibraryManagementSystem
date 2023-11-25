using System.Linq.Expressions;

namespace LibraryManagementSystem.DataAccess.Repo.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Get(Expression<Func<T, bool>> filter);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Add(T entity);
    }
}
