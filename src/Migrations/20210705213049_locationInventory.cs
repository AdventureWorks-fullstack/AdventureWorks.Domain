using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureWorks.Domain.Migrations
{
    public partial class locationInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bin",
                schema: "Production",
                table: "ProductInventory");

            migrationBuilder.DropColumn(
                name: "Shelf",
                schema: "Production",
                table: "ProductInventory");

            migrationBuilder.AddColumn<short>(
                name: "LocationInventoryId",
                schema: "Production",
                table: "ProductInventory",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LocationInventory",
                columns: table => new
                {
                    LocationInventoryId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<short>(type: "smallint", nullable: false),
                    Shelf = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_LocationInventoryId",
                schema: "Production",
                table: "ProductInventory",
                column: "LocationInventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationInventory_LocationId",
                table: "LocationInventory",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInventory_LocationInventory_LocationInventoryId",
                schema: "Production",
                table: "ProductInventory",
                column: "LocationInventoryId",
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
                name: "LocationInventory");

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
