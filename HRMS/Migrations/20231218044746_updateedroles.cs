using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    public partial class updateedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01845f0b-4bbe-4ad4-8675-9b9ad5e8ddfe", "2", "Employee", "Employee" },
                    { "304a1cba-af86-4d4e-90dc-f377480331b3", "4", "Manager", "Manager" },
                    { "3e9fafb5-789f-46fb-a7f4-bb104a980e70", "1", "Admin", "Admin" },
                    { "6b5a9f65-c631-4209-938e-c6428351c130", "3", "HR", "HR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01845f0b-4bbe-4ad4-8675-9b9ad5e8ddfe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "304a1cba-af86-4d4e-90dc-f377480331b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e9fafb5-789f-46fb-a7f4-bb104a980e70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b5a9f65-c631-4209-938e-c6428351c130");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3321e552-f6c5-4935-a869-e5d968126589", "4", "Manager", "Manager" },
                    { "725c88e8-ef98-4363-8000-06eac17793f4", "1", "Administrator", "Administrator" },
                    { "9dae3f78-2ca4-4c40-8948-a7eda7735fb3", "2", "Employee", "Employee" },
                    { "ffc4145c-1a3e-4c6b-9420-daf4f3d19fba", "3", "HR", "HR" }
                });
        }
    }
}
