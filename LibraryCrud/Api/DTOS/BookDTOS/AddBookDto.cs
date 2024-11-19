using LibraryCrud.Api.DTOS.AuthorDTOS;
using LibraryCrud.Api.DTOS.GenreDTOS;

namespace LibraryCrud.Api.DTOS.BookDTOS
{
    public class AddBookDto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime PublicationDate { get; set; }
        public List<GenreIdDto> Genres { get; set; }
        public List<AuthorIdDto> Authors { get; set; }
    }
}
