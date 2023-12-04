using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    public partial class change_emp_table_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpDtl_AspNetUsers_UserId",
                table: "EmpDtl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpDtl",
                table: "EmpDtl");

            migrationBuilder.RenameTable(
                name: "EmpDtl",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_EmpDtl_UserId",
                table: "Employees",
                newName: "IX_Employees_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "EmpDtl");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UserId",
                table: "EmpDtl",
                newName: "IX_EmpDtl_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpDtl",
                table: "EmpDtl",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpDtl_AspNetUsers_UserId",
                table: "EmpDtl",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
