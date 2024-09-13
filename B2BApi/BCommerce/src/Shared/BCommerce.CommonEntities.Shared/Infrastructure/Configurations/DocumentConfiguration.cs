using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class DocumentConfiguration : IEntityTypeConfiguration<BCOMDocument>
    {
        public void Configure(EntityTypeBuilder<BCOMDocument> builder)
        {
            builder.ToTable(nameof(BCOMDocument), "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
        }
    }
}
