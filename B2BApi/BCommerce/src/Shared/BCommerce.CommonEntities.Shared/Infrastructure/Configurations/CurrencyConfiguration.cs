using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class CurrencyConfiguration:IEntityTypeConfiguration<BCOMCurrency>
    {
        public void Configure(EntityTypeBuilder<BCOMCurrency> builder)
        {
            builder.ToTable(nameof(BCOMCurrency), "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
        }
    }
}
