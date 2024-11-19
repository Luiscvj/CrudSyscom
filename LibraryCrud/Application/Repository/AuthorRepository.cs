using LibraryCrud.Domain.Entities;
using LibraryCrud.Domain.Interfaces;
using LibraryCrud.Persistence;

namespace LibraryCrud.Application.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthor
    {
        public AuthorRepository(LibraryCrudContext context):base(context)
        {
            
        }


    }
}
