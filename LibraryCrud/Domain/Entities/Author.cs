using System.ComponentModel.DataAnnotations;

namespace LibraryCrud.Domain.Entities
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime Birth { get; set; }
        public ICollection<Book>? Books { get; set; } = new List<Book>();


    }
}
