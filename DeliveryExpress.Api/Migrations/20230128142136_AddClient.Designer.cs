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
    [Migration("20230128142136_AddClient")]
    partial class AddClient
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("DeliveryRequestseq", "DeliveryRequest")
                .IncrementsBy(10);

            modelBuilder.Entity("DeliveryExpress.Domain.DeliveryRequestAggregator.DeliveryRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "DeliveryRequestseq", "DeliveryRequest");

                    b.Property<int>("Contact")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeliveryDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 1, 28, 11, 21, 36, 114, DateTimeKind.Local).AddTicks(1508))
                        .HasColumnName("DeliveryDate");

                    b.Property<int>("clientId")
                        .HasColumnType("int")
                        .HasColumnName("ClientId");

                    b.Property<int>("contactId")
                        .HasColumnType("int")
                        .HasColumnName("ContactId");

                    b.HasKey("Id");

                    b.ToTable("DeliveryRequests", "DeliveryRequest");
                });

            modelBuilder.Entity("DeliveryExpress.Domain.DeliveryRequestAggregator.DeliveryRequest", b =>
                {
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
#pragma warning restore 612, 618
        }
    }
}
