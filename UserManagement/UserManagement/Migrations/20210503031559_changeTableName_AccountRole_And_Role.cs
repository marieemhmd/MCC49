using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.Migrations
{
    public partial class changeTableName_AccountRole_And_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRoles_Roles_RoleId",
                table: "AccountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRoles_tb_t_accounts_AccountId",
                table: "AccountRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountRoles",
                table: "AccountRoles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "tb_m_roles");

            migrationBuilder.RenameTable(
                name: "AccountRoles",
                newName: "tb_t_accountRoles");

            migrationBuilder.RenameIndex(
                name: "IX_AccountRoles_RoleId",
                table: "tb_t_accountRoles",
                newName: "IX_tb_t_accountRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_roles",
                table: "tb_m_roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_t_accountRoles",
                table: "tb_t_accountRoles",
                columns: new[] { "AccountId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_tb_t_accountRoles_tb_m_roles_RoleId",
                table: "tb_t_accountRoles",
                column: "RoleId",
                principalTable: "tb_m_roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_t_accountRoles_tb_t_accounts_AccountId",
                table: "tb_t_accountRoles",
                column: "AccountId",
                principalTable: "tb_t_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_t_accountRoles_tb_m_roles_RoleId",
                table: "tb_t_accountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_t_accountRoles_tb_t_accounts_AccountId",
                table: "tb_t_accountRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_t_accountRoles",
                table: "tb_t_accountRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_roles",
                table: "tb_m_roles");

            migrationBuilder.RenameTable(
                name: "tb_t_accountRoles",
                newName: "AccountRoles");

            migrationBuilder.RenameTable(
                name: "tb_m_roles",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_tb_t_accountRoles_RoleId",
                table: "AccountRoles",
                newName: "IX_AccountRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountRoles",
                table: "AccountRoles",
                columns: new[] { "AccountId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_Roles_RoleId",
                table: "AccountRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_tb_t_accounts_AccountId",
                table: "AccountRoles",
                column: "AccountId",
                principalTable: "tb_t_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
