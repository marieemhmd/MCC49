using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addAtributinEmployeeAndRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "TB_M_Request",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadDoc",
                table: "TB_M_Request",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "TB_M_Employee",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "TB_M_Request");

            migrationBuilder.DropColumn(
                name: "UploadDoc",
                table: "TB_M_Request");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "TB_M_Employee");

        }
    }
}
