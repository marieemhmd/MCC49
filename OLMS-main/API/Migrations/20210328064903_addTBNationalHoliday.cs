using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addTBNationalHoliday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "TB_M_NationalHoliday",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_NationalHoliday_RequestId",
                table: "TB_M_NationalHoliday",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_M_NationalHoliday_TB_M_Request_RequestId",
                table: "TB_M_NationalHoliday",
                column: "RequestId",
                principalTable: "TB_M_Request",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_M_NationalHoliday_TB_M_Request_RequestId",
                table: "TB_M_NationalHoliday");

            migrationBuilder.DropIndex(
                name: "IX_TB_M_NationalHoliday_RequestId",
                table: "TB_M_NationalHoliday");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "TB_M_NationalHoliday");
        }
    }
}
