using DeliveryExpress.Infrastructure.DeliveryRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryExpress.Infrastructure.Client
{
    public class ClientConfiguration : IEntityTypeConfiguration<Domain.ClientAggregator.Client>
    {
        public void Configure(EntityTypeBuilder<Domain.ClientAggregator.Client> builder)
        {
            _ = builder.ToTable("Clients", DeliveryExpressContext.DEFAULT_SCHEMA);
            _ = builder.HasKey(x => x.Id);
            _ = builder.Ignore(x => x.DomainEvents);
            _ = builder.Property(x => x.Id).UseHiLo("clientseq", DeliveryExpressContext.DEFAULT_SCHEMA);
            _ = builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
            _ = builder.Property(x => x.Email).HasColumnName("Email").IsRequired();
            _ = builder.Property(x => x.Phone).HasColumnName("Phone").IsRequired();
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
        }
    }
}