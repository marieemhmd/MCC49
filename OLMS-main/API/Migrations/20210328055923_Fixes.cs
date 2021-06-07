using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_NationalHoliday",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_NationalHoliday", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Parameter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Parameter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Position",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Position_TB_M_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TB_M_Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Employee",
                columns: table => new
                {
                    NIK = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 14, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    RemainingQuota = table.Column<int>(nullable: false),
                    NIK_Manager = table.Column<string>(nullable: true),
                    PositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Employee", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Employee_NIK_Manager",
                        column: x => x.NIK_Manager,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_M_Employee_TB_M_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "TB_M_Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Account",
                columns: table => new
                {
                    NIK = table.Column<string>(nullable: false),
                    AccountPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Account", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_TB_M_Account_TB_M_Employee_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Request",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonRequest = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    RequestStatus = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: false),
                    ApprovedHRD = table.Column<string>(nullable: true),
                    ApprovedManager = table.Column<string>(nullable: true),
                    NIK_Employee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Request_TB_M_Employee_NIK_Employee",
                        column: x => x.NIK_Employee,
                        principalTable: "TB_M_Employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_T_AccountRole",
                columns: table => new
                {
                    NIK = table.Column<string>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_T_AccountRole", x => new { x.NIK, x.RoleID });
                    table.ForeignKey(
                        name: "FK_TB_T_AccountRole_TB_M_Account_NIK",
                        column: x => x.NIK,
                        principalTable: "TB_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_T_AccountRole_TB_M_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "TB_M_Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_NIK_Manager",
                table: "TB_M_Employee",
                column: "NIK_Manager");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Employee_PositionId",
                table: "TB_M_Employee",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Position_DepartmentId",
                table: "TB_M_Position",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Request_NIK_Employee",
                table: "TB_M_Request",
                column: "NIK_Employee");

            migrationBuilder.CreateIndex(
                name: "IX_TB_T_AccountRole_RoleID",
                table: "TB_T_AccountRole",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_NationalHoliday");

            migrationBuilder.DropTable(
                name: "TB_M_Parameter");

            migrationBuilder.DropTable(
                name: "TB_M_Request");

            migrationBuilder.DropTable(
                name: "TB_T_AccountRole");

            migrationBuilder.DropTable(
                name: "TB_M_Account");

            migrationBuilder.DropTable(
                name: "TB_M_Role");

            migrationBuilder.DropTable(
                name: "TB_M_Employee");

            migrationBuilder.DropTable(
                name: "TB_M_Position");

            migrationBuilder.DropTable(
                name: "TB_M_Department");
        }
    }
}
