using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class seededmoredata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email" },
                values: new object[] { 1, "areyes986@gmail.com" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email" },
                values: new object[] { 2, "jinwoov@gmail.com" });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "ID", "InventoryID", "Qty", "UserID" },
                values: new object[] { 1, 3, 2, 1 });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "ID", "InventoryID", "Qty", "UserID" },
                values: new object[] { 2, 2, 5, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
