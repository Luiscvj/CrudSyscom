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


                    },
                     new Author
                     {
                         AuthorId = 2,
                         AuthorName = "Isabel Allende",
                         Birth = new DateTime(1942, 08, 02)
                     },
                    new Author
                    {
                        AuthorId = 3,
                        AuthorName = "Jorge Luis Borges",
                        Birth = new DateTime(1899, 08, 24)
                    },
                    new Author
                    {
                        AuthorId = 4,
                        AuthorName = "Mario Vargas Llosa",
                        Birth = new DateTime(1936, 03, 28)
                    },
                    new Author
                    {
                        AuthorId = 5,
                        AuthorName = "Octavio Paz",
                        Birth = new DateTime(1914, 03, 31)
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

                    },

                     new Book
                     {
                         BookId = 2,
                         BookTitle = "El Amor en los Tiempos del Cólera",
                         PublicationDate = new DateTime(1985, 09, 15)
                     },

                    // Isabel Allende
                    new Book
                    {
                        BookId = 3,
                        BookTitle = "La Casa de los Espíritus",
                        PublicationDate = new DateTime(1982, 10, 01)
                    },
                    new Book
                    {
                        BookId = 4,
                        BookTitle = "De Amor y de Sombra",
                        PublicationDate = new DateTime(1984, 06, 12)
                    },

                    // Jorge Luis Borges
                    new Book
                    {
                        BookId = 5,
                        BookTitle = "Ficciones",
                        PublicationDate = new DateTime(1944, 01, 01)
                    },
                    new Book
                    {
                        BookId = 6,
                        BookTitle = "El Aleph",
                        PublicationDate = new DateTime(1949, 01, 01)
                    },

                    // Mario Vargas Llosa
                    new Book
                    {
                        BookId = 7,
                        BookTitle = "La Ciudad y los Perros",
                        PublicationDate = new DateTime(1963, 01, 01)
                    },
                    new Book
                    {
                        BookId = 8,
                        BookTitle = "La Fiesta del Chivo",
                        PublicationDate = new DateTime(2000, 11, 01)
                    },

                    // Octavio Paz
                    new Book
                    {
                        BookId = 9,
                        BookTitle = "El Laberinto de la Soledad",
                        PublicationDate = new DateTime(1950, 01, 01)
                    },
                    new Book
                    {
                        BookId = 10,
                        BookTitle = "Piedra de Sol",
                        PublicationDate = new DateTime(1957, 01, 01)
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
                        // Gabriel García Márquez
                        new BookAuthor { BookId = 1, AuthorId = 1 },
                        new BookAuthor { BookId = 2, AuthorId = 1 },

                        // Isabel Allende
                        new BookAuthor { BookId = 3, AuthorId = 2 },
                        new BookAuthor { BookId = 4, AuthorId = 2 },

                        // Jorge Luis Borges
                        new BookAuthor { BookId = 5, AuthorId = 3 },
                        new BookAuthor { BookId = 6, AuthorId = 3 },

                        // Mario Vargas Llosa
                        new BookAuthor { BookId = 7, AuthorId = 4 },
                        new BookAuthor { BookId = 8, AuthorId = 4 },

                        // Octavio Paz
                        new BookAuthor { BookId = 9, AuthorId = 5 },
                        new BookAuthor { BookId = 10, AuthorId = 5 }
                    );

            builder.Entity<BookGenre>()
                     .HasData
                     (
                         // Gabriel García Márquez
                         new BookGenre { BookId = 1, GenreId = 1 }, // Realismo Mágico
                         new BookGenre { BookId = 1, GenreId = 7 }, // Drama
                         new BookGenre { BookId = 2, GenreId = 1 }, // Realismo Mágico
                         new BookGenre { BookId = 2, GenreId = 7 }, // Drama

                         // Isabel Allende
                         new BookGenre { BookId = 3, GenreId = 1 }, // Realismo Mágico
                         new BookGenre { BookId = 3, GenreId = 7 }, // Drama
                         new BookGenre { BookId = 4, GenreId = 1 }, // Realismo Mágico
                         new BookGenre { BookId = 4, GenreId = 7 }, // Drama

                         // Jorge Luis Borges
                         new BookGenre { BookId = 5, GenreId = 3 }, // Ficción
                         new BookGenre { BookId = 5, GenreId = 2 }, // Fantasía
                         new BookGenre { BookId = 6, GenreId = 3 }, // Ficción
                         new BookGenre { BookId = 6, GenreId = 2 }, // Fantasía

                         // Mario Vargas Llosa
                         new BookGenre { BookId = 7, GenreId = 7 }, // Drama
                         new BookGenre { BookId = 8, GenreId = 7 }, // Drama

                         // Octavio Paz
                         new BookGenre { BookId = 9, GenreId = 4 }, // No Ficción
                         new BookGenre { BookId = 10, GenreId = 4 }  // No Ficción
                     );
        }
    }
}
