using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryExpress.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddProductPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "DeliveryRequest",
                table: "Product",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 15, 30, 53, 648, DateTimeKind.Local).AddTicks(940),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 15, 28, 8, 255, DateTimeKind.Local).AddTicks(4627));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "DeliveryRequest",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 15, 28, 8, 255, DateTimeKind.Local).AddTicks(4627),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 15, 30, 53, 648, DateTimeKind.Local).AddTicks(940));
        }
    }
}
