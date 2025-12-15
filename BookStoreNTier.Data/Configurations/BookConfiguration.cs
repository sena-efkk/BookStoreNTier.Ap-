using BookStoreNTier.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreNTier.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Price).HasPrecision(18, 2);

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Books)
                   .HasForeignKey(x => x.CategoryId);

            builder.ToTable("Books");
        }
    }
}