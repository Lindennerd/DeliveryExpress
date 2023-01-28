using DeliveryExpress.Infrastructure.DeliveryRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryExpress.Infrastructure.Product
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.ProductAggregator.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.ProductAggregator.Product> builder)
        {
            _ = builder.ToTable("Product", DeliveryExpressContext.DEFAULT_SCHEMA);
            _ = builder.HasKey(x => x.Id);
            _ = builder.Ignore(x => x.DomainEvents);
            _ = builder.Property(x => x.Id).UseHiLo("productseq", DeliveryExpressContext.DEFAULT_SCHEMA);
            _ = builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
            _ = builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(500).IsRequired();
            _ = builder.Property(x => x.Price).HasColumnName("Price").HasColumnType("decimal").IsRequired();
        }
    }
}