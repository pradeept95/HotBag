using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotBag.EntityFrameworkCore.Migrations
{
    public partial class generictestcontrollerwithentityframework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotBagApplicationModule_HotBagUser_CreatedByUser",
                table: "HotBagApplicationModule");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagApplicationModule_HotBagUser_UpdatedByUser",
                table: "HotBagApplicationModule");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagApplicationModulePermissionLevel_HotBagUser_CreatedByUser",
                table: "HotBagApplicationModulePermissionLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagApplicationModulePermissionLevel_HotBagUser_UpdatedByUser",
                table: "HotBagApplicationModulePermissionLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagPasswordHistoryLog_HotBagUser_CreatedByUser",
                table: "HotBagPasswordHistoryLog");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagPasswordHistoryLog_HotBagUser_UpdatedByUser",
                table: "HotBagPasswordHistoryLog");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagRole_HotBagUser_CreatedByUser",
                table: "HotBagRole");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagRole_HotBagUser_UpdatedByUser",
                table: "HotBagRole");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagRoleApplicationModule_HotBagUser_CreatedByUser",
                table: "HotBagRoleApplicationModule");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagRoleApplicationModule_HotBagUser_UpdatedByUser",
                table: "HotBagRoleApplicationModule");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagUser_HotBagUser_CreatedByUser",
                table: "HotBagUser");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagUser_HotBagUser_UpdatedByUser",
                table: "HotBagUser");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagUserRoles_HotBagUser_CreatedByUser",
                table: "HotBagUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagUserRoles_HotBagUser_UpdatedByUser",
                table: "HotBagUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagUserStatusLog_HotBagUser_CreatedByUser",
                table: "HotBagUserStatusLog");

            migrationBuilder.DropForeignKey(
                name: "FK_HotBagUserStatusLog_HotBagUser_UpdatedByUser",
                table: "HotBagUserStatusLog");

            migrationBuilder.DropForeignKey(
                name: "FK_TestEntity_HotBagUser_CreatedByUser",
                table: "TestEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TestEntity_HotBagUser_UpdatedByUser",
                table: "TestEntity");

            migrationBuilder.DropIndex(
                name: "IX_TestEntity_CreatedByUser",
                table: "TestEntity");

            migrationBuilder.DropIndex(
                name: "IX_TestEntity_UpdatedByUser",
                table: "TestEntity");

            migrationBuilder.DropIndex(
                name: "IX_HotBagUserStatusLog_CreatedByUser",
                table: "HotBagUserStatusLog");

            migrationBuilder.DropIndex(
                name: "IX_HotBagUserStatusLog_UpdatedByUser",
                table: "HotBagUserStatusLog");

            migrationBuilder.DropIndex(
                name: "IX_HotBagUserRoles_CreatedByUser",
                table: "HotBagUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_HotBagUserRoles_UpdatedByUser",
                table: "HotBagUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_HotBagUser_CreatedByUser",
                table: "HotBagUser");

            migrationBuilder.DropIndex(
                name: "IX_HotBagUser_UpdatedByUser",
                table: "HotBagUser");

            migrationBuilder.DropIndex(
                name: "IX_HotBagRoleApplicationModule_CreatedByUser",
                table: "HotBagRoleApplicationModule");

            migrationBuilder.DropIndex(
                name: "IX_HotBagRoleApplicationModule_UpdatedByUser",
                table: "HotBagRoleApplicationModule");

            migrationBuilder.DropIndex(
                name: "IX_HotBagRole_CreatedByUser",
                table: "HotBagRole");

            migrationBuilder.DropIndex(
                name: "IX_HotBagRole_UpdatedByUser",
                table: "HotBagRole");

            migrationBuilder.DropIndex(
                name: "IX_HotBagPasswordHistoryLog_CreatedByUser",
                table: "HotBagPasswordHistoryLog");

            migrationBuilder.DropIndex(
                name: "IX_HotBagPasswordHistoryLog_UpdatedByUser",
                table: "HotBagPasswordHistoryLog");

            migrationBuilder.DropIndex(
                name: "IX_HotBagApplicationModulePermissionLevel_CreatedByUser",
                table: "HotBagApplicationModulePermissionLevel");

            migrationBuilder.DropIndex(
                name: "IX_HotBagApplicationModulePermissionLevel_UpdatedByUser",
                table: "HotBagApplicationModulePermissionLevel");

            migrationBuilder.DropIndex(
                name: "IX_HotBagApplicationModule_CreatedByUser",
                table: "HotBagApplicationModule");

            migrationBuilder.DropIndex(
                name: "IX_HotBagApplicationModule_UpdatedByUser",
                table: "HotBagApplicationModule");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "TestEntity");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "TestEntity");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "TestEntity");

            migrationBuilder.DropColumn(
                name: "UpdatedByUser",
                table: "TestEntity");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "HotBagUserStatusLog");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "HotBagUserStatusLog");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "HotBagUserStatusLog");

            migrationBuilder.DropColumn(
                name: "UpdatedByUser",
                table: "HotBagUserStatusLog");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "HotBagUserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "HotBagUserRoles");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "HotBagUserRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedByUser",
                table: "HotBagUserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "HotBagUser");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "HotBagUser");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "HotBagUser");

            migrationBuilder.DropColumn(
                name: "UpdatedByUser",
                table: "HotBagUser");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "HotBagRoleApplicationModule");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "HotBagRoleApplicationModule");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "HotBagRoleApplicationModule");

            migrationBuilder.DropColumn(
                name: "UpdatedByUser",
                table: "HotBagRoleApplicationModule");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "HotBagRole");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "HotBagRole");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "HotBagRole");

            migrationBuilder.DropColumn(
                name: "UpdatedByUser",
                table: "HotBagRole");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "HotBagPasswordHistoryLog");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "HotBagPasswordHistoryLog");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "HotBagPasswordHistoryLog");

            migrationBuilder.DropColumn(
                name: "UpdatedByUser",
                table: "HotBagPasswordHistoryLog");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "HotBagApplicationModulePermissionLevel");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "HotBagApplicationModulePermissionLevel");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "HotBagApplicationModulePermissionLevel");

            migrationBuilder.DropColumn(
                name: "UpdatedByUser",
                table: "HotBagApplicationModulePermissionLevel");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "HotBagApplicationModule");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "HotBagApplicationModule");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "HotBagApplicationModule");

            migrationBuilder.DropColumn(
                name: "UpdatedByUser",
                table: "HotBagApplicationModule");

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pradeep",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pradeep", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Pradeep");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUser",
                table: "TestEntity",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "TestEntity",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "TestEntity",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUser",
                table: "TestEntity",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUser",
                table: "HotBagUserStatusLog",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "HotBagUserStatusLog",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "HotBagUserStatusLog",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUser",
                table: "HotBagUserStatusLog",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUser",
                table: "HotBagUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "HotBagUserRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "HotBagUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUser",
                table: "HotBagUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUser",
                table: "HotBagUser",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "HotBagUser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "HotBagUser",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUser",
                table: "HotBagUser",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUser",
                table: "HotBagRoleApplicationModule",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "HotBagRoleApplicationModule",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "HotBagRoleApplicationModule",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUser",
                table: "HotBagRoleApplicationModule",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUser",
                table: "HotBagRole",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "HotBagRole",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "HotBagRole",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUser",
                table: "HotBagRole",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUser",
                table: "HotBagPasswordHistoryLog",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "HotBagPasswordHistoryLog",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "HotBagPasswordHistoryLog",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUser",
                table: "HotBagPasswordHistoryLog",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUser",
                table: "HotBagApplicationModulePermissionLevel",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "HotBagApplicationModulePermissionLevel",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "HotBagApplicationModulePermissionLevel",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUser",
                table: "HotBagApplicationModulePermissionLevel",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUser",
                table: "HotBagApplicationModule",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "HotBagApplicationModule",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "HotBagApplicationModule",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUser",
                table: "HotBagApplicationModule",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestEntity_CreatedByUser",
                table: "TestEntity",
                column: "CreatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_TestEntity_UpdatedByUser",
                table: "TestEntity",
                column: "UpdatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagUserStatusLog_CreatedByUser",
                table: "HotBagUserStatusLog",
                column: "CreatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagUserStatusLog_UpdatedByUser",
                table: "HotBagUserStatusLog",
                column: "UpdatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagUserRoles_CreatedByUser",
                table: "HotBagUserRoles",
                column: "CreatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagUserRoles_UpdatedByUser",
                table: "HotBagUserRoles",
                column: "UpdatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagUser_CreatedByUser",
                table: "HotBagUser",
                column: "CreatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagUser_UpdatedByUser",
                table: "HotBagUser",
                column: "UpdatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagRoleApplicationModule_CreatedByUser",
                table: "HotBagRoleApplicationModule",
                column: "CreatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagRoleApplicationModule_UpdatedByUser",
                table: "HotBagRoleApplicationModule",
                column: "UpdatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagRole_CreatedByUser",
                table: "HotBagRole",
                column: "CreatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagRole_UpdatedByUser",
                table: "HotBagRole",
                column: "UpdatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagPasswordHistoryLog_CreatedByUser",
                table: "HotBagPasswordHistoryLog",
                column: "CreatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagPasswordHistoryLog_UpdatedByUser",
                table: "HotBagPasswordHistoryLog",
                column: "UpdatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagApplicationModulePermissionLevel_CreatedByUser",
                table: "HotBagApplicationModulePermissionLevel",
                column: "CreatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagApplicationModulePermissionLevel_UpdatedByUser",
                table: "HotBagApplicationModulePermissionLevel",
                column: "UpdatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagApplicationModule_CreatedByUser",
                table: "HotBagApplicationModule",
                column: "CreatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagApplicationModule_UpdatedByUser",
                table: "HotBagApplicationModule",
                column: "UpdatedByUser");

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagApplicationModule_HotBagUser_CreatedByUser",
                table: "HotBagApplicationModule",
                column: "CreatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagApplicationModule_HotBagUser_UpdatedByUser",
                table: "HotBagApplicationModule",
                column: "UpdatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagApplicationModulePermissionLevel_HotBagUser_CreatedByUser",
                table: "HotBagApplicationModulePermissionLevel",
                column: "CreatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagApplicationModulePermissionLevel_HotBagUser_UpdatedByUser",
                table: "HotBagApplicationModulePermissionLevel",
                column: "UpdatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagPasswordHistoryLog_HotBagUser_CreatedByUser",
                table: "HotBagPasswordHistoryLog",
                column: "CreatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagPasswordHistoryLog_HotBagUser_UpdatedByUser",
                table: "HotBagPasswordHistoryLog",
                column: "UpdatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagRole_HotBagUser_CreatedByUser",
                table: "HotBagRole",
                column: "CreatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagRole_HotBagUser_UpdatedByUser",
                table: "HotBagRole",
                column: "UpdatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagRoleApplicationModule_HotBagUser_CreatedByUser",
                table: "HotBagRoleApplicationModule",
                column: "CreatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagRoleApplicationModule_HotBagUser_UpdatedByUser",
                table: "HotBagRoleApplicationModule",
                column: "UpdatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagUser_HotBagUser_CreatedByUser",
                table: "HotBagUser",
                column: "CreatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagUser_HotBagUser_UpdatedByUser",
                table: "HotBagUser",
                column: "UpdatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagUserRoles_HotBagUser_CreatedByUser",
                table: "HotBagUserRoles",
                column: "CreatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagUserRoles_HotBagUser_UpdatedByUser",
                table: "HotBagUserRoles",
                column: "UpdatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagUserStatusLog_HotBagUser_CreatedByUser",
                table: "HotBagUserStatusLog",
                column: "CreatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotBagUserStatusLog_HotBagUser_UpdatedByUser",
                table: "HotBagUserStatusLog",
                column: "UpdatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestEntity_HotBagUser_CreatedByUser",
                table: "TestEntity",
                column: "CreatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestEntity_HotBagUser_UpdatedByUser",
                table: "TestEntity",
                column: "UpdatedByUser",
                principalTable: "HotBagUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
