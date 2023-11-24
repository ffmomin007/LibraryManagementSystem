using LibraryManagementSystem.DataAccess.Data;
using LibraryManagementSystem.DataAccess.Repo.Implementation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Repo.Interface
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

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
            return entity ;
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
