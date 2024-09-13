using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class FunctionConfiguration : IEntityTypeConfiguration<BCOMFunction>
    {
        public void Configure(EntityTypeBuilder<BCOMFunction> builder)
        {
            builder.ToTable(nameof(BCOMFunction), "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
        }
    }
}
