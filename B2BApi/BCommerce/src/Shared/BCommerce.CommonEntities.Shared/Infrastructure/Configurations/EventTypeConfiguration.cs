using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Configurations
{
    public class EventTypeConfiguration : IEntityTypeConfiguration<BCOMEventType>
    {
        public void Configure(EntityTypeBuilder<BCOMEventType> builder)
        {
            builder.ToTable(nameof(BCOMEventType), "dbo");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
        }
    }
}
