using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyEmployeesCoreWebAPI.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1913e13-bc40-456f-b8c0-439cf1fe0296", "fcdcaf28-1ee7-41ff-aba4-6c3c3e07e0ed", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01960c97-346c-4e3e-9b08-61b8fe561be3", "d706e3cc-3cd8-45b7-8dc4-71417fcb024b", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01960c97-346c-4e3e-9b08-61b8fe561be3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1913e13-bc40-456f-b8c0-439cf1fe0296");
        }
    }
}
