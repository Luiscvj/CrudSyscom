using LibraryCrud.Domain.Entities;
using LibraryCrud.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryCrud.Persistence
{
    public class LibraryCrudContext : DbContext//Esta clase es la que me permite  comunicarme con mi motor de base de datos y manipular los datos
    {
        public LibraryCrudContext(DbContextOptions options) : base(options)
        {    
        
        }
        //Hacemos referencias a las tablas de nuestra base de datos
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor>  BookAuthors{ get; set; } 
        public DbSet<BookGenre>  BookGenres{ get; set; }
        public DbSet<Genre> Genres { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            Seeding.Seed(builder);


        }
    

    }
    
}
