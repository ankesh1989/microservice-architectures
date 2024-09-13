using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<BCOMCountry>
    {
        public void Configure(EntityTypeBuilder<BCOMCountry> builder)
        {
            builder.ToTable(nameof(BCOMCountry),"dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
        }
    }
}