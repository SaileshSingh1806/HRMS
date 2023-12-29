using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    public partial class addedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3321e552-f6c5-4935-a869-e5d968126589", "4", "Manager", "Manager" },
                    { "725c88e8-ef98-4363-8000-06eac17793f4", "1", "Admin", "Admin" },
                    { "9dae3f78-2ca4-4c40-8948-a7eda7735fb3", "2", "Employee", "Employee" },
                    { "ffc4145c-1a3e-4c6b-9420-daf4f3d19fba", "3", "HR", "HR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3321e552-f6c5-4935-a869-e5d968126589");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "725c88e8-ef98-4363-8000-06eac17793f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dae3f78-2ca4-4c40-8948-a7eda7735fb3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffc4145c-1a3e-4c6b-9420-daf4f3d19fba");
        }
    }
}
