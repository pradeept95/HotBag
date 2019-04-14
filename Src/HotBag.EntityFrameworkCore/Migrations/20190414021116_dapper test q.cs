using Microsoft.EntityFrameworkCore.Migrations;

namespace HotBag.EntityFrameworkCore.Migrations
{
    public partial class dappertestq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DapperTestEnties",
                table: "DapperTestEnties");

            migrationBuilder.RenameTable(
                name: "DapperTestEnties",
                newName: "DapperTestEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DapperTestEntity",
                table: "DapperTestEntity",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DapperTestEntity",
                table: "DapperTestEntity");

            migrationBuilder.RenameTable(
                name: "DapperTestEntity",
                newName: "DapperTestEnties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DapperTestEnties",
                table: "DapperTestEnties",
                column: "Id");
        }
    }
}
