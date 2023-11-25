using LibraryManagementSystem.DataAccess.Data;
using LibraryManagementSystem.DataAccess.Repo.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryManagementSystem.DataAccess.Repo.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T Get(int id)
        {
            T? entity = _context.Set<T>().Find(id);
            return entity;
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            var entity = _context.Set<T>().FirstOrDefault(filter);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            var entities = _context.Set<T>();

            return entities;
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
        }
    }
}
