using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class SupplierConfigConfiguration : IEntityTypeConfiguration<BCOMSupplierConfig>
    {
        public void Configure(EntityTypeBuilder<BCOMSupplierConfig> builder)
        {
            builder.ToTable(nameof(BCOMSupplierConfig), "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
        }
    }
}
