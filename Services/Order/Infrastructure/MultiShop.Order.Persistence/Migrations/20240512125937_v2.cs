using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.Order.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderingId1",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderingId1",
                table: "OrderDetails",
                column: "OrderingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orderings_OrderingId1",
                table: "OrderDetails",
                column: "OrderingId1",
                principalTable: "Orderings",
                principalColumn: "OrderingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orderings_OrderingId1",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderingId1",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderingId1",
                table: "OrderDetails");
        }
    }
}
