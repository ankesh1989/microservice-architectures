using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class UserprivilegeConfiguration : IEntityTypeConfiguration<BCOMUserprivilege>
    {
        public void Configure(EntityTypeBuilder<BCOMUserprivilege> builder)
        {
            builder.ToTable(nameof(BCOMUserprivilege), "dbo");
            builder.HasKey(p => p.Id);
        }
    }
}
