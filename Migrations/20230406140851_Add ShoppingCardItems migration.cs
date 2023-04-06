using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kotabko.Migrations
{
    /// <inheritdoc />
    public partial class AddShoppingCardItemsmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_books_BookId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_orders_OrderId",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "orderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                table: "orderItems",
                newName: "IX_orderItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_BookId",
                table: "orderItems",
                newName: "IX_orderItems_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "shoppingCardItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCardId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCardItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingCardItems_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCardItems_BookId",
                table: "shoppingCardItems",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_books_BookId",
                table: "orderItems",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_orders_OrderId",
                table: "orderItems",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_books_BookId",
                table: "orderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_orders_OrderId",
                table: "orderItems");

            migrationBuilder.DropTable(
                name: "shoppingCardItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderItems",
                table: "orderItems");

            migrationBuilder.RenameTable(
                name: "orderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_orderItems_OrderId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_orderItems_BookId",
                table: "OrderItem",
                newName: "IX_OrderItem_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_books_BookId",
                table: "OrderItem",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_orders_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
