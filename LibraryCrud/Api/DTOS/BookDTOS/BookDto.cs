using LibraryCrud.Api.DTOS.AuthorDTOS;
using LibraryCrud.Api.DTOS.GenreDTOS;
using LibraryCrud.Domain.Entities;

namespace LibraryCrud.Api.DTOS.BookDTOS
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime PublicationDate { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
        public ICollection<AuthorDto> Authors { get; set; } 
    }
}
