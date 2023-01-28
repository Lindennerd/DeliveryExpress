using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryExpress.Infrastructure.DeliveryRequest
{
    public class DeliveryRequestConfiguration : IEntityTypeConfiguration<Domain.DeliveryRequestAggregator.DeliveryRequest>
    {
        public void Configure(EntityTypeBuilder<Domain.DeliveryRequestAggregator.DeliveryRequest> builder)
        {
            _ = builder.ToTable("DeliveryRequest", DeliveryExpressContext.DEFAULT_SCHEMA);
            _ = builder.HasKey(x => x.Id);
            _ = builder.Ignore(x => x.DomainEvents);
            _ = builder.Property(x => x.Id).UseHiLo("DeliveryRequestseq", DeliveryExpressContext.DEFAULT_SCHEMA);
            _ = builder.Property(x => x.DeliveryDate).HasColumnName("DeliveryDate").HasDefaultValue(DateTime.Now).IsRequired();
            _ = builder.OwnsOne(x => x.Address, e =>
            {
                _ = e.Property(x => x.Street).HasColumnName("Street").HasMaxLength(200).IsRequired();
                _ = e.Property(x => x.City).HasColumnName("City").HasMaxLength(100).IsRequired();
                _ = e.Property(x => x.State).HasColumnName("State").HasMaxLength(100).IsRequired();
                _ = e.Property(x => x.ZipCode).HasColumnName("ZipCode").HasMaxLength(18).IsRequired();
                _ = e.Property(x => x.Complement).HasColumnName("Complement").HasMaxLength(100);
                _ = e.Property(x => x.Neighborhood).HasColumnName("Neighborhood").HasMaxLength(100).IsRequired();
                _ = e.Property(x => x.Number).HasColumnName("Number").IsRequired();
                _ = e.WithOwner();
            });
            _ = builder.OwnsOne(x => x.Status, e =>
            {
                _ = e.Property(x => x.Id).HasColumnName("StatusId").IsRequired();
                _ = e.Property(x => x.Name).HasColumnName("StatusName").HasMaxLength(100).IsRequired();
                _ = e.WithOwner();
            });

            builder?
                .Metadata
                .FindNavigation(nameof(Domain.DeliveryRequestAggregator.DeliveryRequest.Items))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            _ = builder.HasOne<Domain.ClientAggregator.Client>()
                .WithMany()
                .HasForeignKey("clientId");
        }
    }
}