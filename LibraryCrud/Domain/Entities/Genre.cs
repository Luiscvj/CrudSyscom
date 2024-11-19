using System.ComponentModel.DataAnnotations;

namespace LibraryCrud.Domain.Entities
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public ICollection<Book>? Books { get; set; } = new List<Book>();
    }
}
