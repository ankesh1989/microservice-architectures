using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<BCOMProduct>
    {
        public void Configure(EntityTypeBuilder<BCOMProduct> builder)
        {
            builder.ToTable(nameof(BCOMProduct), "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
        }
    }
}
