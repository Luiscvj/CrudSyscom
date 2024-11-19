using LibraryCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryCrud.Persistence.Data.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genre");

            builder.Property(x => x.GenreName)
                   .HasMaxLength(120)
                   .IsRequired();
        }
    }
}
