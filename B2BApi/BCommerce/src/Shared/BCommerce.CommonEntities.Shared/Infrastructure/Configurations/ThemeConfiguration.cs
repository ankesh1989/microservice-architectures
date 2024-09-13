using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class ThemeConfiguration : IEntityTypeConfiguration<BCOMTheme>
    {
        public void Configure(EntityTypeBuilder<BCOMTheme> builder)
        {
            builder.ToTable(nameof(BCOMTheme), "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
        }
    }
}
