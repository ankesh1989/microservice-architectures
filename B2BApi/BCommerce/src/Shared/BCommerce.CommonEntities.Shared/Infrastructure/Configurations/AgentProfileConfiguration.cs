using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class AgentProfileConfiguration : IEntityTypeConfiguration<BCOMAgentProfile>
    {
        public void Configure(EntityTypeBuilder<BCOMAgentProfile> builder)
        {
            builder.ToTable(nameof(BCOMAgentProfile), "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
        }
    }
}
