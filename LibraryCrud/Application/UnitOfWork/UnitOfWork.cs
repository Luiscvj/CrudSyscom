using LibraryCrud.Application.Repository;
using LibraryCrud.Domain.Interfaces;
using LibraryCrud.Persistence;

namespace LibraryCrud.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        //Se usa el patro UnitOfWork util en Ef Core para centralizar las transacciones  con los repositorios
        //Se usa el patron repositorio para tener acceso a la logica de forma ordenada y modularizada
        AuthorRepository _Author;
        BookRepository _Book;
        GenreRepository _Genre;

        private readonly LibraryCrudContext _context;

        public UnitOfWork(LibraryCrudContext context)
        {
            _context = context; 
        }
//Aplica lazy loading para solo instanciar los repositorios cuando los necesite y asi administrar mejor la carga en la app
        public IAuthor Authors
        {
            get
            {
                _Author ??= new AuthorRepository(_context);
                return _Author;
            }
        }

        public IBook Books
        {
            get
            {
                _Book ??= new BookRepository(_context);
                return _Book;
            }
        }

        public IGenre Genres
        {
            get
            {
                _Genre ??= new GenreRepository(_context);
                return _Genre;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return  await _context.SaveChangesAsync();
        }

    }
}
