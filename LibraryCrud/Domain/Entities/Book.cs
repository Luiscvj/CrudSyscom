using System.ComponentModel.DataAnnotations;

namespace LibraryCrud.Domain.Entities
{
    //Se define la clase Book identificando cada libro del sistema
    public class Book
    {
        [Key]//Uso de DataAnotations
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public DateTime PublicationDate { get; set; }
        public ICollection<Genre>? Genres { get; set; } = new List<Genre>();
        public ICollection<Author> Authors { get; set; } = new List<Author>();


    }
}
