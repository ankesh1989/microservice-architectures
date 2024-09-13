using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class ExchangeRateConfiguration : IEntityTypeConfiguration<BCOMExchangeRate>
    {
        public void Configure(EntityTypeBuilder<BCOMExchangeRate> builder)
        {
            builder.ToTable(nameof(BCOMExchangeRate), "dbo");
            builder.HasKey(p => p.Id);
        }
    }
}
