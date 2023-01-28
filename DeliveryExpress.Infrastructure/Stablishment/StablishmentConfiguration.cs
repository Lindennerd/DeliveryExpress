using DeliveryExpress.Infrastructure.DeliveryRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryExpress.Infrastructure.Stablishment
{
    public class StablishmentConfiguration : IEntityTypeConfiguration<Domain.StablishmentAggregator.Stablishment>
    {
        public void Configure(EntityTypeBuilder<Domain.StablishmentAggregator.Stablishment> builder)
        {
            _ = builder.ToTable("Stablishment", DeliveryExpressContext.DEFAULT_SCHEMA);
            _ = builder.Ignore(x => x.DomainEvents);
            _ = builder.HasKey(x => x.Id);
            _ = builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
            _ = builder.Property(x => x.Phone).HasColumnName("Phone").HasMaxLength(20).IsRequired();

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

            _ = builder.HasMany(x => x.Products)
                .WithOne()
                .HasForeignKey("stablishmentId");

            _ = builder.HasMany(x => x.Clients)
                .WithOne()
                .HasForeignKey("stablishmentId");

            _ = (builder?.Metadata.FindNavigation(nameof(Domain.StablishmentAggregator.Stablishment.Products)));
            _ = (builder?.Metadata.FindNavigation(nameof(Domain.StablishmentAggregator.Stablishment.Clients)));
        }
    }
}