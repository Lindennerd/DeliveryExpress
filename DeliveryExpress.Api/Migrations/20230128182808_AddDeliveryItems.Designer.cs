﻿// <auto-generated />
using System;
using DeliveryExpress.Infrastructure.DeliveryRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeliveryExpress.Api.Migrations
{
    [DbContext(typeof(DeliveryExpressContext))]
    [Migration("20230128182808_AddDeliveryItems")]
    partial class AddDeliveryItems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("clientseq", "DeliveryRequest")
                .IncrementsBy(10);

            modelBuilder.HasSequence("DeliveryItemseq", "DeliveryRequest")
                .IncrementsBy(10);

            modelBuilder.HasSequence("DeliveryRequestseq", "DeliveryRequest")
                .IncrementsBy(10);

            modelBuilder.HasSequence("productseq", "DeliveryRequest")
                .IncrementsBy(10);

            modelBuilder.Entity("DeliveryExpress.Domain.ClientAggregator.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "clientseq", "DeliveryRequest");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Phone");

                    b.Property<int?>("_stablishmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("_stablishmentId");

                    b.ToTable("Clients", "DeliveryRequest");
                });

            modelBuilder.Entity("DeliveryExpress.Domain.DeliveryRequestAggregator.DeliveryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "DeliveryItemseq", "DeliveryRequest");

                    b.Property<int?>("DeliveryRequestId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.Property<int>("_deliveryRequestId")
                        .HasColumnType("int");

                    b.Property<int>("_productId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryRequestId");

                    b.HasIndex("_deliveryRequestId");

                    b.HasIndex("_productId");

                    b.ToTable("DeliveryItem", "DeliveryRequest");
                });

            modelBuilder.Entity("DeliveryExpress.Domain.DeliveryRequestAggregator.DeliveryRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "DeliveryRequestseq", "DeliveryRequest");

                    b.Property<DateTime?>("DeliveryDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 1, 28, 15, 28, 8, 255, DateTimeKind.Local).AddTicks(4627))
                        .HasColumnName("DeliveryDate");

                    b.Property<int>("_clientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("_clientId");

                    b.ToTable("DeliveryRequests", "DeliveryRequest");
                });

            modelBuilder.Entity("DeliveryExpress.Domain.ProductAggregator.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "productseq", "DeliveryRequest");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.Property<int?>("_stablishmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("_stablishmentId");

                    b.ToTable("Product", "DeliveryRequest");
                });

            modelBuilder.Entity("DeliveryExpress.Domain.StablishmentAggregator.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Phone");

                    b.Property<int>("_stablishmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("_stablishmentId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("DeliveryExpress.Domain.StablishmentAggregator.Stablishment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Phone");

                    b.HasKey("Id");

                    b.ToTable("Stablishment", "DeliveryRequest");
                });

            modelBuilder.Entity("DeliveryExpress.Domain.ClientAggregator.Client", b =>
                {
                    b.HasOne("DeliveryExpress.Domain.StablishmentAggregator.Stablishment", null)
                        .WithMany("Clients")
                        .HasForeignKey("_stablishmentId");

                    b.OwnsOne("DeliveryExpress.Domain.Common.AddressValueObject.Address", "Address", b1 =>
                        {
                            b1.Property<int>("ClientId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("City");

                            b1.Property<string>("Complement")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Complement");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Neighborhood");

                            b1.Property<int>("Number")
                                .HasColumnType("int")
                                .HasColumnName("Number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(18)
                                .HasColumnType("nvarchar(18)")
                                .HasColumnName("ZipCode");

                            b1.HasKey("ClientId");

                            b1.ToTable("Clients", "DeliveryRequest");

                            b1.WithOwner()
                                .HasForeignKey("ClientId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryExpress.Domain.DeliveryRequestAggregator.DeliveryItem", b =>
                {
                    b.HasOne("DeliveryExpress.Domain.DeliveryRequestAggregator.DeliveryRequest", null)
                        .WithMany("Items")
                        .HasForeignKey("DeliveryRequestId");

                    b.HasOne("DeliveryExpress.Domain.DeliveryRequestAggregator.DeliveryRequest", null)
                        .WithMany()
                        .HasForeignKey("_deliveryRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryExpress.Domain.ProductAggregator.Product", null)
                        .WithMany()
                        .HasForeignKey("_productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryExpress.Domain.DeliveryRequestAggregator.DeliveryRequest", b =>
                {
                    b.HasOne("DeliveryExpress.Domain.ClientAggregator.Client", null)
                        .WithMany()
                        .HasForeignKey("_clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("DeliveryExpress.Domain.Common.AddressValueObject.Address", "Address", b1 =>
                        {
                            b1.Property<int>("DeliveryRequestId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("City");

                            b1.Property<string>("Complement")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Complement");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Neighborhood");

                            b1.Property<int>("Number")
                                .HasColumnType("int")
                                .HasColumnName("Number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(18)
                                .HasColumnType("nvarchar(18)")
                                .HasColumnName("ZipCode");

                            b1.HasKey("DeliveryRequestId");

                            b1.ToTable("DeliveryRequests", "DeliveryRequest");

                            b1.WithOwner()
                                .HasForeignKey("DeliveryRequestId");
                        });

                    b.OwnsOne("DeliveryExpress.Domain.DeliveryRequestAggregator.DeliveryRequestStatus", "Status", b1 =>
                        {
                            b1.Property<int>("DeliveryRequestId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .HasColumnType("int")
                                .HasColumnName("StatusId");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("StatusName");

                            b1.HasKey("DeliveryRequestId");

                            b1.ToTable("DeliveryRequests", "DeliveryRequest");

                            b1.WithOwner()
                                .HasForeignKey("DeliveryRequestId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Status")
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryExpress.Domain.ProductAggregator.Product", b =>
                {
                    b.HasOne("DeliveryExpress.Domain.StablishmentAggregator.Stablishment", null)
                        .WithMany("Products")
                        .HasForeignKey("_stablishmentId");
                });

            modelBuilder.Entity("DeliveryExpress.Domain.StablishmentAggregator.Contact", b =>
                {
                    b.HasOne("DeliveryExpress.Domain.StablishmentAggregator.Stablishment", "Stablishment")
                        .WithMany("Contacts")
                        .HasForeignKey("_stablishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stablishment");
                });

            modelBuilder.Entity("DeliveryExpress.Domain.StablishmentAggregator.Stablishment", b =>
                {
                    b.OwnsOne("DeliveryExpress.Domain.Common.AddressValueObject.Address", "Address", b1 =>
                        {
                            b1.Property<int>("StablishmentId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("City");

                            b1.Property<string>("Complement")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Complement");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Neighborhood");

                            b1.Property<int>("Number")
                                .HasColumnType("int")
                                .HasColumnName("Number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(18)
                                .HasColumnType("nvarchar(18)")
                                .HasColumnName("ZipCode");

                            b1.HasKey("StablishmentId");

                            b1.ToTable("Stablishment", "DeliveryRequest");

                            b1.WithOwner()
                                .HasForeignKey("StablishmentId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryExpress.Domain.DeliveryRequestAggregator.DeliveryRequest", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("DeliveryExpress.Domain.StablishmentAggregator.Stablishment", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Contacts");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
