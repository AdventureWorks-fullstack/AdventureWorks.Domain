using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureWorks.Domain.Migrations
{
    public partial class LocationInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER TABLE Production.ProductInventory
                    DROP constraint CK_ProductInventory_Shelf");

            migrationBuilder.Sql(
                @"ALTER TABLE Production.ProductInventory
                DROP constraint CK_ProductInventory_Bin");

            migrationBuilder.DropColumn(
                name: "Bin",
                schema: "Production",
                table: "ProductInventory");

            migrationBuilder.DropColumn(
                name: "Shelf",
                schema: "Production",
                table: "ProductInventory");

            migrationBuilder.AddColumn<string>(
                name: "LocationInventoryId",
                schema: "Production",
                table: "ProductInventory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocationInventory",
                schema: "Production",
                columns: table => new
                {
                    LocationInventoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationInventory", x => x.LocationInventoryId);
                    table.ForeignKey(
                        name: "FK_LocationInventory_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Production",
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationInventoryHistory",
                schema: "Production",
                columns: table => new
                {
                    LocationInventoryHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationInventoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LocationId = table.Column<short>(type: "smallint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    MovedHereWhen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovedHereEmployeeBusinessEntityId = table.Column<int>(type: "int", nullable: true),
                    ProductInventoryLocationId = table.Column<short>(type: "smallint", nullable: true),
                    ProductInventoryProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationInventoryHistory", x => x.LocationInventoryHistoryId);
                    table.ForeignKey(
                        name: "FK_LocationInventoryHistory_Employee_MovedHereEmployeeBusinessEntityId",
                        column: x => x.MovedHereEmployeeBusinessEntityId,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocationInventoryHistory_LocationInventory_LocationInventoryId",
                        column: x => x.LocationInventoryId,
                        principalSchema: "Production",
                        principalTable: "LocationInventory",
                        principalColumn: "LocationInventoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocationInventoryHistory_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Production",
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationInventoryHistory_ProductInventory_ProductInventoryProductId_ProductInventoryLocationId",
                        columns: x => new { x.ProductInventoryProductId, x.ProductInventoryLocationId },
                        principalSchema: "Production",
                        principalTable: "ProductInventory",
                        principalColumns: new[] { "ProductID", "LocationID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_LocationInventoryId",
                schema: "Production",
                table: "ProductInventory",
                column: "LocationInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationInventory_LocationId",
                schema: "Production",
                table: "LocationInventory",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationInventoryHistory_LocationInventoryId",
                schema: "Production",
                table: "LocationInventoryHistory",
                column: "LocationInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationInventoryHistory_MovedHereEmployeeBusinessEntityId",
                schema: "Production",
                table: "LocationInventoryHistory",
                column: "MovedHereEmployeeBusinessEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationInventoryHistory_ProductId",
                schema: "Production",
                table: "LocationInventoryHistory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationInventoryHistory_ProductInventoryProductId_ProductInventoryLocationId",
                schema: "Production",
                table: "LocationInventoryHistory",
                columns: new[] { "ProductInventoryProductId", "ProductInventoryLocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventory_LocationInventory_LocationInventoryId",
                schema: "Production",
                table: "ProductInventory",
                column: "LocationInventoryId",
                principalSchema: "Production",
                principalTable: "LocationInventory",
                principalColumn: "LocationInventoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInventory_LocationInventory_LocationInventoryId",
                schema: "Production",
                table: "ProductInventory");

            migrationBuilder.DropTable(
                name: "LocationInventoryHistory",
                schema: "Production");

            migrationBuilder.DropTable(
                name: "LocationInventory",
                schema: "Production");

            migrationBuilder.DropIndex(
                name: "IX_ProductInventory_LocationInventoryId",
                schema: "Production",
                table: "ProductInventory");

            migrationBuilder.DropColumn(
                name: "LocationInventoryId",
                schema: "Production",
                table: "ProductInventory");

            migrationBuilder.AddColumn<byte>(
                name: "Bin",
                schema: "Production",
                table: "ProductInventory",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "Storage container on a shelf in an inventory location.");

            migrationBuilder.AddColumn<string>(
                name: "Shelf",
                schema: "Production",
                table: "ProductInventory",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "Storage compartment within an inventory location.");
        }
    }
}
