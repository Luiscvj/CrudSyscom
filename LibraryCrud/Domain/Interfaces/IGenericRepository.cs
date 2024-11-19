using System.Linq.Expressions;

namespace LibraryCrud.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //Creo este generico para poder implementarlo de los diferentes repositorios
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
