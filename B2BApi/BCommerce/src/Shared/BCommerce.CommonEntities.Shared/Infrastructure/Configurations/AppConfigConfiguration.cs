using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class AppConfigConfiguration : IEntityTypeConfiguration<BCOMAppConfig>
    {
        public void Configure(EntityTypeBuilder<BCOMAppConfig> builder)
        {
            builder.ToTable(nameof(BCOMAppConfig), "dbo");
            builder.HasKey(p => p.Id);
        }
    }
}
