using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class PrivilegeConfiguration : IEntityTypeConfiguration<BCOMPrivilege>
    {
        public void Configure(EntityTypeBuilder<BCOMPrivilege> builder)
        {
            builder.ToTable(nameof(BCOMPrivilege), "dbo");
            builder.HasKey(p => p.Id);
        }
    }
}
