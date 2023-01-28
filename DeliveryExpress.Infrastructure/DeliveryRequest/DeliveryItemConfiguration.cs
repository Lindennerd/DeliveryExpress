using DeliveryExpress.Domain.DeliveryRequestAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryExpress.Infrastructure.DeliveryRequest
{
    public class DeliveryItemConfiguration : IEntityTypeConfiguration<DeliveryItem>
    {
        public void Configure(EntityTypeBuilder<DeliveryItem> builder)
        {
            _ = builder.ToTable("DeliveryItem", DeliveryExpressContext.DEFAULT_SCHEMA);
            _ = builder.HasKey(x => x.Id);
            _ = builder.Ignore(x => x.DomainEvents);
            _ = builder.Property(x => x.Id).UseHiLo("DeliveryItemseq", DeliveryExpressContext.DEFAULT_SCHEMA);
            _ = builder.Property(x => x.Quantity).HasColumnName("Quantity").IsRequired();

            _ = builder.HasOne<Domain.ProductAggregator.Product>()
                .WithMany()
                .HasForeignKey("productId");
        }
    }
}