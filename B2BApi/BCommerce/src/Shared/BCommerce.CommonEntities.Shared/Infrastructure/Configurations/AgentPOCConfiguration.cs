using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class AgentPOCConfiguration : IEntityTypeConfiguration<BCOMAgentPOC>
    {
        public void Configure(EntityTypeBuilder<BCOMAgentPOC> builder)
        {
            builder.ToTable(nameof(BCOMAgentPOC), "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName).IsRequired();
        }
    }
}
