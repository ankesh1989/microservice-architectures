
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class AgentPgConfiguration : IEntityTypeConfiguration<BCOMAgentPg>
    {
        public void Configure(EntityTypeBuilder<BCOMAgentPg> builder)
        {
            builder.ToTable(nameof(BCOMAgentPg), "dbo");
            builder.HasKey(p => p.Id);
        }
    }
}
