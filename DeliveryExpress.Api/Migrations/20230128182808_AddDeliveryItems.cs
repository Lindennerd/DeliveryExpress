using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryExpress.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDeliveryItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests");

            migrationBuilder.DropColumn(
                name: "Contact",
                schema: "DeliveryRequest",
                table: "DeliveryRequests");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                newName: "_clientId");

            migrationBuilder.CreateSequence(
                name: "DeliveryItemseq",
                schema: "DeliveryRequest",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "productseq",
                schema: "DeliveryRequest",
                incrementBy: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 15, 28, 8, 255, DateTimeKind.Local).AddTicks(4627),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 11, 29, 59, 951, DateTimeKind.Local).AddTicks(5329));

            migrationBuilder.AddColumn<int>(
                name: "_stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stablishment",
                schema: "DeliveryRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stablishment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    stablishmentId = table.Column<int>(name: "_stablishmentId", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Stablishment__stablishmentId",
                        column: x => x.stablishmentId,
                        principalSchema: "DeliveryRequest",
                        principalTable: "Stablishment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "DeliveryRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    stablishmentId = table.Column<int>(name: "_stablishmentId", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Stablishment__stablishmentId",
                        column: x => x.stablishmentId,
                        principalSchema: "DeliveryRequest",
                        principalTable: "Stablishment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryItem",
                schema: "DeliveryRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DeliveryRequestId = table.Column<int>(type: "int", nullable: true),
                    deliveryRequestId = table.Column<int>(name: "_deliveryRequestId", type: "int", nullable: false),
                    productId = table.Column<int>(name: "_productId", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryItem_DeliveryRequests_DeliveryRequestId",
                        column: x => x.DeliveryRequestId,
                        principalSchema: "DeliveryRequest",
                        principalTable: "DeliveryRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveryItem_DeliveryRequests__deliveryRequestId",
                        column: x => x.deliveryRequestId,
                        principalSchema: "DeliveryRequest",
                        principalTable: "DeliveryRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryItem_Product__productId",
                        column: x => x.productId,
                        principalSchema: "DeliveryRequest",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryRequests__clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                column: "_clientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients__stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients",
                column: "_stablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts__stablishmentId",
                table: "Contacts",
                column: "_stablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryItem__deliveryRequestId",
                schema: "DeliveryRequest",
                table: "DeliveryItem",
                column: "_deliveryRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryItem__productId",
                schema: "DeliveryRequest",
                table: "DeliveryItem",
                column: "_productId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryItem_DeliveryRequestId",
                schema: "DeliveryRequest",
                table: "DeliveryItem",
                column: "DeliveryRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Product__stablishmentId",
                schema: "DeliveryRequest",
                table: "Product",
                column: "_stablishmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Stablishment__stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients",
                column: "_stablishmentId",
                principalSchema: "DeliveryRequest",
                principalTable: "Stablishment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryRequests_Clients__clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                column: "_clientId",
                principalSchema: "DeliveryRequest",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Stablishment__stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryRequests_Clients__clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "DeliveryItem",
                schema: "DeliveryRequest");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "DeliveryRequest");

            migrationBuilder.DropTable(
                name: "Stablishment",
                schema: "DeliveryRequest");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryRequests__clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests");

            migrationBuilder.DropIndex(
                name: "IX_Clients__stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "_stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients");

            migrationBuilder.DropSequence(
                name: "DeliveryItemseq",
                schema: "DeliveryRequest");

            migrationBuilder.DropSequence(
                name: "productseq",
                schema: "DeliveryRequest");

            migrationBuilder.RenameColumn(
                name: "_clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                newName: "ContactId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 11, 29, 59, 951, DateTimeKind.Local).AddTicks(5329),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 15, 28, 8, 255, DateTimeKind.Local).AddTicks(4627));

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Contact",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
