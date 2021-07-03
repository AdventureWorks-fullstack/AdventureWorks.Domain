using Microsoft.EntityFrameworkCore.Migrations;

namespace AdventureWorks.Domain.Migrations
{
    public partial class salesdetailproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderDetail_Product_ProductID",
                schema: "Sales",
                table: "SalesOrderDetail",
                column: "ProductID",
                principalSchema: "Production",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderDetail_Product_ProductID",
                schema: "Sales",
                table: "SalesOrderDetail");
        }
    }
}
