using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<BCOMRole>
    {
        public void Configure(EntityTypeBuilder<BCOMRole> builder)
        {
            builder.ToTable(nameof(BCOMRole), "dbo");
            builder.HasKey(p => p.Id);
        }
    }
}
