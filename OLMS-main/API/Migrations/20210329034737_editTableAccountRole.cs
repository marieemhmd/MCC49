using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class editTableAccountRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_NationalHoliday_TB_M_Request_RequestId",
                table: "TB_M_NationalHoliday");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_AccountRole",
                table: "TB_T_AccountRole");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "TB_M_NationalHoliday",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_AccountRole",
                table: "TB_T_AccountRole",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_NationalHoliday_TB_M_Request_RequestId",
                table: "TB_M_NationalHoliday",
                column: "RequestId",
                principalTable: "TB_M_Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_NationalHoliday_TB_M_Request_RequestId",
                table: "TB_M_NationalHoliday");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_T_AccountRole",
                table: "TB_T_AccountRole");

            migrationBuilder.AlterColumn<int>(
                name: "RequestId",
                table: "TB_M_NationalHoliday",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_T_AccountRole",
                table: "TB_T_AccountRole",
                columns: new[] { "NIK", "RoleID" });

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_NationalHoliday_TB_M_Request_RequestId",
                table: "TB_M_NationalHoliday",
                column: "RequestId",
                principalTable: "TB_M_Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
