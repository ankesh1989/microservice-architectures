using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<BCOMUserRole>
    {
        public void Configure(EntityTypeBuilder<BCOMUserRole> builder)
        {
            builder.ToTable(nameof(BCOMUserRole), "dbo");
            builder.HasKey(p => p.Id);
        }
    }
}
