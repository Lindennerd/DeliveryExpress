using DeliveryExpress.Domain.StablishmentAggregator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryExpress.Infrastructure.Stablishment
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            _ = builder.Ignore(x => x.DomainEvents);
            _ = builder.HasKey(x => x.Id);
            _ = builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(200).IsRequired();
            _ = builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(200).IsRequired();
            _ = builder.Property(x => x.Phone).HasColumnName("Phone").HasMaxLength(200).IsRequired();

            _ = builder.Metadata.FindNavigation(nameof(Contact.Stablishment));

            _ = builder.HasOne(x => x.Stablishment)
                .WithMany(x => x.Contacts)
                .HasForeignKey("stablishmentId");
        }
    }
}