using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class FieldTypeConfiguration : IEntityTypeConfiguration<BCOMFieldType>
    {
        public void Configure(EntityTypeBuilder<BCOMFieldType> builder)
        {
            builder.ToTable(nameof(BCOMFieldType), "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Type).IsRequired();
        }
    }
}
