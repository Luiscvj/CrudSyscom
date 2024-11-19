using LibraryCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryCrud.Persistence.Seed
{
    public class Seeding
    {
        //Insercion de datos iniciales para prueba del api

        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Author>()
                .HasData
                (
                    new Author
                    {
                        AuthorId = 1,
                        AuthorName = "Gabriel Garcia Marquez",
                        Birth = new DateTime(1927, 03, 06)


                    }
                );

            builder.Entity<Book>()
                .HasData
                (
                    new Book
                    {
                        BookId = 1,
                        BookTitle = "Cien Años de Soledad",
                        PublicationDate = new DateTime(1967, 05, 10),

                    }
                );


            builder.Entity<Genre>()
                   .HasData
                     (
                        new Genre
                        {
                            GenreId = 1,
                            GenreName = "RealismoMagico"
                        },

                        new Genre
                        {
                            GenreId = 2,
                            GenreName = "Fantasia"
                        },

                        new Genre
                        {
                            GenreId = 3,
                            GenreName = "Ficcion"
                        },

                        new Genre
                        {
                            GenreId = 4,
                            GenreName = "NoFiccion"
                        },

                        new Genre
                        {
                            GenreId = 5,
                            GenreName = "Terror"
                        },

                        new Genre
                        {
                            GenreId = 6,
                            GenreName = "CienciaFiccion"
                        },

                        new Genre
                        {
                            GenreId = 7,
                            GenreName = "Drama"
                        }


                     );

            builder.Entity<BookAuthor>()
                    .HasData
                    (
                        new BookAuthor
                        {
                            BookId = 1,
                            AuthorId = 1
                        }
                    );
            
            builder.Entity<BookGenre>()
                    .HasData
                    (
                        new BookGenre
                        {
                            BookId = 1,
                            GenreId = 1
                        },
                        new BookGenre
                        {
                            BookId = 1,
                            GenreId = 2
                        }
                    );
        }
    }
}
