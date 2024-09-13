using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<BCOMSupplier>
    {
        public void Configure(EntityTypeBuilder<BCOMSupplier> builder)
        {
            builder.ToTable(nameof(BCOMSupplier), "dbo");
            builder.HasKey(p => p.Id);

        }
    }
}