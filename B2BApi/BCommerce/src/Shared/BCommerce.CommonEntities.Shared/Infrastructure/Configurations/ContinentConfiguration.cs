using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class ContinentConfiguration : IEntityTypeConfiguration<BCOMContinent>
    {
        public void Configure(EntityTypeBuilder<BCOMContinent> builder)
        {
            builder.ToTable(nameof(BCOMContinent), "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
        }
    }
}
