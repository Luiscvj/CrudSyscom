using LibraryCrud.Domain.Interfaces;
using LibraryCrud.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryCrud.Application.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly LibraryCrudContext _context;
        public GenericRepository(LibraryCrudContext context)
        {
            this._context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);//Calls the DbSet of the entity T to adding to the collection
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }

}
