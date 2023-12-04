using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    public partial class modify_fk_in_emp_and_leave_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_EmpDtl_EmployeeId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_User_userid",
                table: "LeaveRequest");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRoleType");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequest_EmployeeId",
                table: "LeaveRequest");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequest_userid",
                table: "LeaveRequest");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "LeaveRequest");

            migrationBuilder.DropColumn(
                name: "RequestedById",
                table: "LeaveRequest");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "LeaveRequest");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "LeaveRequest",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AppliedTo",
                table: "LeaveRequest",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "RequestedBy",
                table: "LeaveRequest",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EmpDtl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_AppliedTo",
                table: "LeaveRequest",
                column: "AppliedTo");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_ApprovedBy",
                table: "LeaveRequest",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_RequestedBy",
                table: "LeaveRequest",
                column: "RequestedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmpDtl_UserId",
                table: "EmpDtl",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpDtl_AspNetUsers_UserId",
                table: "EmpDtl",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_AppliedTo",
                table: "LeaveRequest",
                column: "AppliedTo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_ApprovedBy",
                table: "LeaveRequest",
                column: "ApprovedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_RequestedBy",
                table: "LeaveRequest",
                column: "RequestedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpDtl_AspNetUsers_UserId",
                table: "EmpDtl");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_AppliedTo",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_ApprovedBy",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_RequestedBy",
                table: "LeaveRequest");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequest_AppliedTo",
                table: "LeaveRequest");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequest_ApprovedBy",
                table: "LeaveRequest");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequest_RequestedBy",
                table: "LeaveRequest");

            migrationBuilder.DropIndex(
                name: "IX_EmpDtl_UserId",
                table: "EmpDtl");

            migrationBuilder.DropColumn(
                name: "RequestedBy",
                table: "LeaveRequest");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EmpDtl");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovedBy",
                table: "LeaveRequest",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "AppliedTo",
                table: "LeaveRequest",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "LeaveRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestedById",
                table: "LeaveRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "LeaveRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserRoleType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userRoleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_UserRoleType_userRoleTypeId",
                        column: x => x.userRoleTypeId,
                        principalTable: "UserRoleType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_EmployeeId",
                table: "LeaveRequest",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_userid",
                table: "LeaveRequest",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_User_userRoleTypeId",
                table: "User",
                column: "userRoleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_EmpDtl_EmployeeId",
                table: "LeaveRequest",
                column: "EmployeeId",
                principalTable: "EmpDtl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_User_userid",
                table: "LeaveRequest",
                column: "userid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
