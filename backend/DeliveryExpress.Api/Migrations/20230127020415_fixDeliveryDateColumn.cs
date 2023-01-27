using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryExpress.Api.Migrations
{
    /// <inheritdoc />
    public partial class fixDeliveryDateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 26, 23, 4, 15, 754, DateTimeKind.Local).AddTicks(6590),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 26, 23, 4, 15, 754, DateTimeKind.Local).AddTicks(6590));

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 26, 19, 34, 5, 593, DateTimeKind.Local).AddTicks(6991));
        }
    }
}
