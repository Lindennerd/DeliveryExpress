using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryExpress.Api.Migrations
{
    /// <inheritdoc />
    public partial class NameStandarization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Stablishment__stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Stablishment__stablishmentId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryItem_DeliveryRequests_DeliveryRequestId",
                schema: "DeliveryRequest",
                table: "DeliveryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryItem_DeliveryRequests__deliveryRequestId",
                schema: "DeliveryRequest",
                table: "DeliveryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryItem_Product__productId",
                schema: "DeliveryRequest",
                table: "DeliveryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryRequests_Clients__clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Stablishment__stablishmentId",
                schema: "DeliveryRequest",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryItem__deliveryRequestId",
                schema: "DeliveryRequest",
                table: "DeliveryItem");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryItem__productId",
                schema: "DeliveryRequest",
                table: "DeliveryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryRequests",
                schema: "DeliveryRequest",
                table: "DeliveryRequests");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryRequests__clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests");

            migrationBuilder.DropColumn(
                name: "_deliveryRequestId",
                schema: "DeliveryRequest",
                table: "DeliveryItem");

            migrationBuilder.DropColumn(
                name: "_productId",
                schema: "DeliveryRequest",
                table: "DeliveryItem");

            migrationBuilder.DropColumn(
                name: "_clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests");

            migrationBuilder.RenameTable(
                name: "DeliveryRequests",
                schema: "DeliveryRequest",
                newName: "DeliveryRequest",
                newSchema: "DeliveryRequest");

            migrationBuilder.RenameColumn(
                name: "_stablishmentId",
                schema: "DeliveryRequest",
                table: "Product",
                newName: "stablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Product__stablishmentId",
                schema: "DeliveryRequest",
                table: "Product",
                newName: "IX_Product_stablishmentId");

            migrationBuilder.RenameColumn(
                name: "_stablishmentId",
                table: "Contacts",
                newName: "stablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts__stablishmentId",
                table: "Contacts",
                newName: "IX_Contacts_stablishmentId");

            migrationBuilder.RenameColumn(
                name: "_stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients",
                newName: "stablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients__stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients",
                newName: "IX_Clients_stablishmentId");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                schema: "DeliveryRequest",
                table: "DeliveryItem",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 16, 13, 43, 53, DateTimeKind.Local).AddTicks(2584),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 15, 30, 53, 648, DateTimeKind.Local).AddTicks(940));

            migrationBuilder.AddColumn<int>(
                name: "clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequest",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryRequest",
                schema: "DeliveryRequest",
                table: "DeliveryRequest",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryItem_productId",
                schema: "DeliveryRequest",
                table: "DeliveryItem",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryRequest_clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequest",
                column: "clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Stablishment_stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients",
                column: "stablishmentId",
                principalSchema: "DeliveryRequest",
                principalTable: "Stablishment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Stablishment_stablishmentId",
                table: "Contacts",
                column: "stablishmentId",
                principalSchema: "DeliveryRequest",
                principalTable: "Stablishment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryItem_DeliveryRequest_DeliveryRequestId",
                schema: "DeliveryRequest",
                table: "DeliveryItem",
                column: "DeliveryRequestId",
                principalSchema: "DeliveryRequest",
                principalTable: "DeliveryRequest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryItem_Product_productId",
                schema: "DeliveryRequest",
                table: "DeliveryItem",
                column: "productId",
                principalSchema: "DeliveryRequest",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryRequest_Clients_clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequest",
                column: "clientId",
                principalSchema: "DeliveryRequest",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Stablishment_stablishmentId",
                schema: "DeliveryRequest",
                table: "Product",
                column: "stablishmentId",
                principalSchema: "DeliveryRequest",
                principalTable: "Stablishment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Stablishment_stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Stablishment_stablishmentId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryItem_DeliveryRequest_DeliveryRequestId",
                schema: "DeliveryRequest",
                table: "DeliveryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryItem_Product_productId",
                schema: "DeliveryRequest",
                table: "DeliveryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryRequest_Clients_clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Stablishment_stablishmentId",
                schema: "DeliveryRequest",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryItem_productId",
                schema: "DeliveryRequest",
                table: "DeliveryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryRequest",
                schema: "DeliveryRequest",
                table: "DeliveryRequest");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryRequest_clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequest");

            migrationBuilder.DropColumn(
                name: "productId",
                schema: "DeliveryRequest",
                table: "DeliveryItem");

            migrationBuilder.DropColumn(
                name: "clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequest");

            migrationBuilder.RenameTable(
                name: "DeliveryRequest",
                schema: "DeliveryRequest",
                newName: "DeliveryRequests",
                newSchema: "DeliveryRequest");

            migrationBuilder.RenameColumn(
                name: "stablishmentId",
                schema: "DeliveryRequest",
                table: "Product",
                newName: "_stablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_stablishmentId",
                schema: "DeliveryRequest",
                table: "Product",
                newName: "IX_Product__stablishmentId");

            migrationBuilder.RenameColumn(
                name: "stablishmentId",
                table: "Contacts",
                newName: "_stablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_stablishmentId",
                table: "Contacts",
                newName: "IX_Contacts__stablishmentId");

            migrationBuilder.RenameColumn(
                name: "stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients",
                newName: "_stablishmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients",
                newName: "IX_Clients__stablishmentId");

            migrationBuilder.AddColumn<int>(
                name: "_deliveryRequestId",
                schema: "DeliveryRequest",
                table: "DeliveryItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "_productId",
                schema: "DeliveryRequest",
                table: "DeliveryItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 28, 15, 30, 53, 648, DateTimeKind.Local).AddTicks(940),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 28, 16, 13, 43, 53, DateTimeKind.Local).AddTicks(2584));

            migrationBuilder.AddColumn<int>(
                name: "_clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryRequests",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                column: "Id");

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
                name: "IX_DeliveryRequests__clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                column: "_clientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Stablishment__stablishmentId",
                schema: "DeliveryRequest",
                table: "Clients",
                column: "_stablishmentId",
                principalSchema: "DeliveryRequest",
                principalTable: "Stablishment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Stablishment__stablishmentId",
                table: "Contacts",
                column: "_stablishmentId",
                principalSchema: "DeliveryRequest",
                principalTable: "Stablishment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryItem_DeliveryRequests_DeliveryRequestId",
                schema: "DeliveryRequest",
                table: "DeliveryItem",
                column: "DeliveryRequestId",
                principalSchema: "DeliveryRequest",
                principalTable: "DeliveryRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryItem_DeliveryRequests__deliveryRequestId",
                schema: "DeliveryRequest",
                table: "DeliveryItem",
                column: "_deliveryRequestId",
                principalSchema: "DeliveryRequest",
                principalTable: "DeliveryRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryItem_Product__productId",
                schema: "DeliveryRequest",
                table: "DeliveryItem",
                column: "_productId",
                principalSchema: "DeliveryRequest",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryRequests_Clients__clientId",
                schema: "DeliveryRequest",
                table: "DeliveryRequests",
                column: "_clientId",
                principalSchema: "DeliveryRequest",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Stablishment__stablishmentId",
                schema: "DeliveryRequest",
                table: "Product",
                column: "_stablishmentId",
                principalSchema: "DeliveryRequest",
                principalTable: "Stablishment",
                principalColumn: "Id");
        }
    }
}
