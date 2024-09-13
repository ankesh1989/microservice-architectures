using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class SupplierDocumentConfiguration : IEntityTypeConfiguration<BCOMSupplierDocument>
    {
        public void Configure(EntityTypeBuilder<BCOMSupplierDocument> builder)
        {
            builder.ToTable(nameof(BCOMSupplierDocument), "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.SupplierId).IsRequired();
            builder.Property(p => p.DocumentPath).IsRequired();
        }
    }
}
