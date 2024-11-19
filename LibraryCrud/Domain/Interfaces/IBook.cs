using LibraryCrud.Domain.Entities;

namespace LibraryCrud.Domain.Interfaces
{
    public interface IBook : IGenericRepository<Book>
    {
        Task<List<Book>> GetBookByAuthor(string authorName);
        Task<List<Book>> GetByName(string bookName);

        Task<bool> verifyAndAddInexistingAuthor(Book book);
        Task<bool> UpdateBook(Book book);

        Task<List<Book>> GetAllBooksLists();
    }
}
