using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class seededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "ID", "Brand", "Description", "Name", "Size" },
                values: new object[] { 1, 0, "Why so expensive? Who knows..", "Shawn Weatherspoon", 11 });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "ID", "Brand", "Description", "Name", "Size" },
                values: new object[] { 2, 1, "My name is Jordan and deez my numbah 1 shoe", "Jordan 1", 12 });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "ID", "Brand", "Description", "Name", "Size" },
                values: new object[] { 3, 1, "Deez shoe is mah numbah 2, and I ain't no foo", "Jordan 2", 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
