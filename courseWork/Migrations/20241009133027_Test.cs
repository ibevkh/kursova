using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace courseWork.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JewelleryDB",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "JewelleryDB",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "JewelleryDB",
                columns: new[] { "Id", "Gemstones", "Material", "Name", "Price", "Size", "Type" },
                values: new object[] { 1, "Test1", "Test1", "Test1", 0, 0, "Test1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JewelleryDB",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "JewelleryDB");

            migrationBuilder.InsertData(
                table: "JewelleryDB",
                columns: new[] { "Id", "Gemstones", "Material", "Name", "Size", "Type" },
                values: new object[] { 1001, "Test1", "Test1", "Test1", 0, "Test1" });
        }
    }
}
