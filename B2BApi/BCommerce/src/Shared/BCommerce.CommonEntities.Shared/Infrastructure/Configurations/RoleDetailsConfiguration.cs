using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class RoleDetailsConfiguration : IEntityTypeConfiguration<BCOMRoleDetails>
    {
        public void Configure(EntityTypeBuilder<BCOMRoleDetails> builder)
        {
            builder.ToTable(nameof(BCOMRoleDetails), "dbo");
            builder.HasKey(p => p.Id);
        }
    }
}
