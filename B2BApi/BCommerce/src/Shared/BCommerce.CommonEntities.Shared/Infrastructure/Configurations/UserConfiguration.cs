using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<BCOMUser>
    {
        public void Configure(EntityTypeBuilder<BCOMUser> builder)
        {
            builder.ToTable(nameof(BCOMUser), "dbo");
            builder.HasKey(p => p.Id);
        }
    }
}
