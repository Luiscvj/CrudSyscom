using LibraryCrud.Domain.Entities;
using LibraryCrud.Domain.Interfaces;
using LibraryCrud.Persistence;

namespace LibraryCrud.Application.Repository
{

    public class GenreRepository: GenericRepository<Genre>, IGenre
    {
        public GenreRepository(LibraryCrudContext context) : base(context)
        {
            
        }

       
    }
}
