using LibraryCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryCrud.Persistence.Data.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            //configuracion de los tipos 
            builder.ToTable("author");

            builder.Property(x => x.AuthorName)
                   .HasMaxLength(120)
                   .IsRequired();

            builder.Property(x => x.Birth)
                    .HasColumnType("date");
        }
    }
}
