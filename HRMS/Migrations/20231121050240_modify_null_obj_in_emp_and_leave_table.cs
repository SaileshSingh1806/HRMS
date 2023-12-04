using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    public partial class modify_null_obj_in_emp_and_leave_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpDtl_AspNetUsers_UserId",
                table: "EmpDtl");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_ApprovedBy",
                table: "LeaveRequest");

            migrationBuilder.DropColumn(
                name: "AppliedDate",
                table: "Leave");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Leave");

            migrationBuilder.DropColumn(
                name: "isSingleDay",
                table: "Leave");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "Leave",
                newName: "FromDate");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "LeaveRequest",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "AppliedDate",
                table: "LeaveRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "LeaveRequest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "Leave",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EmpDtl",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpDtl_AspNetUsers_UserId",
                table: "EmpDtl",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_ApprovedBy",
                table: "LeaveRequest",
                column: "ApprovedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpDtl_AspNetUsers_UserId",
                table: "EmpDtl");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_ApprovedBy",
                table: "LeaveRequest");

            migrationBuilder.DropColumn(
                name: "AppliedDate",
                table: "LeaveRequest");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "LeaveRequest");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "Leave");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "Leave",
                newName: "To");

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "LeaveRequest",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AppliedDate",
                table: "Leave",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Leave",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isSingleDay",
                table: "Leave",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EmpDtl",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpDtl_AspNetUsers_UserId",
                table: "EmpDtl",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_AspNetUsers_ApprovedBy",
                table: "LeaveRequest",
                column: "ApprovedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
