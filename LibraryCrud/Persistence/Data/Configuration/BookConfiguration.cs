using LibraryCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryCrud.Persistence.Data.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void  Configure(EntityTypeBuilder<Book> builder)
        {
            //Configuracion de los tipos y relaciones de la entidad con API Fluent
            builder.ToTable("book");


            builder.Property(x => x.BookTitle)
                .IsRequired()
                .HasMaxLength(180);
            builder.Property(x => x.PublicationDate)
                    .HasColumnType("date");
            builder.HasMany(x => x.Authors)
                    .WithMany(x => x.Books)
                    .UsingEntity<BookAuthor>();

            builder.HasMany(x => x.Genres)
                    .WithMany(x => x.Books)
                    .UsingEntity<BookGenre>();

                    
                    
                    

        }
    }
}
