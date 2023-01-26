using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryExpress.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultDateTimeToDeliveryRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 26, 19, 34, 5, 593, DateTimeKind.Local).AddTicks(6991));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests");
        }
    }
}
