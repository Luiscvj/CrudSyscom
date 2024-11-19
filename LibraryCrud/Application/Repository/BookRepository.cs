using LibraryCrud.Domain.Entities;
using LibraryCrud.Domain.Interfaces;
using LibraryCrud.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LibraryCrud.Application.Repository
{
    public class BookRepository : GenericRepository<Book>, IBook
    {
        public BookRepository(LibraryCrudContext context) : base(context)
        {

        }

        public async Task<List<Book>> GetBookByAuthor(string authorName)
        {
            var book = await _context.Books.Where(c => c.Authors.Any(x => x.AuthorName.Contains(authorName))).Include(x => x.Authors).Include(x => x.Genres).ToListAsync();
            return book;
        }

        public async Task<List<Book>> GetByName(string bookName)
        {
            List<Book> books = await _context.Books.Where(x => x.BookTitle.Contains(bookName)).Include(x => x.Authors).Include(x => x.Genres).ToListAsync();
            return books;
        }

        public  async Task<bool> UpdateBook(Book book)
        {
           
            var existingBook = await _context.Books.Include(x => x.Authors)
                                                    .Include(x => x.Genres)
                                                    .FirstOrDefaultAsync(x => x.BookId == book.BookId);
            existingBook.Genres.Clear();

            existingBook.BookTitle = book.BookTitle;
            existingBook.PublicationDate = book.PublicationDate;
            foreach (var genre in book.Genres)
            {
                var existingGenre = await _context.Genres.FindAsync(genre.GenreId);
                if (existingGenre != null)
                {
                    existingBook.Genres.Add(existingGenre);
                }   
            }


            // Procesar autores
            existingBook.Authors.Clear();
            foreach (var author in book.Authors)
            {
                var existingAuthor = await _context.Authors.FindAsync(author.AuthorId);
                if (existingAuthor != null)
                {
                    existingBook.Authors.Add(existingAuthor);
                }       
            }
                     
            int numChanges = await _context.SaveChangesAsync();
            return numChanges > 0;           
           
        }

        public async Task<bool> verifyAndAddInexistingAuthor(Book bookAuthors)
        {
            var genres = new List<Genre>();
            foreach (var genre in bookAuthors.Genres)
            {
                var existingGenre = await _context.Genres.FindAsync(genre.GenreId);
                if (existingGenre != null)
                {
                    genres.Add(existingGenre);
                }
                else
                {
                    throw new Exception($"Genre with ID {genre.GenreId} does not exist.");
                }
            }
            bookAuthors.Genres = genres;

            // Procesar autores
            var authors = new List<Author>();
            foreach (var author in bookAuthors.Authors)
            {
                var existingAuthor = await _context.Authors.FindAsync(author.AuthorId);
                if (existingAuthor != null)
                {
                    authors.Add(existingAuthor);
                }
                else
                {
                    throw new Exception($"Author with ID {author.AuthorId} does not exist.");
                }
            }
            bookAuthors.Authors = authors;

            // Agregar el libro
            await _context.Books.AddAsync(bookAuthors);
            int numChanges = await _context.SaveChangesAsync();

            return numChanges > 0;
        }
    }
}
