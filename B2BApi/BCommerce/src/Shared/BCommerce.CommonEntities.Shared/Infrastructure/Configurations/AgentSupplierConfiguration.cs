using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class AgentSupplierConfiguration : IEntityTypeConfiguration<BCOMAgentSupplier>
    {
        public void Configure(EntityTypeBuilder<BCOMAgentSupplier> builder)
        {
            builder.ToTable(nameof(BCOMAgentSupplier), "dbo");
            builder.HasKey(p => p.Id);
        }
    }
}
