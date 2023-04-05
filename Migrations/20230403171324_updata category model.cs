using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kotabko.Migrations
{
    /// <inheritdoc />
    public partial class updatacategorymodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
