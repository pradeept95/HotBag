using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotBag.EntityFrameworkCore.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotBagApplicationModule",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuleName = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotBagApplicationModule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotBagRole",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotBagRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Hostnames = table.Column<string>(nullable: true),
                    Theme = table.Column<string>(nullable: true),
                    ConnectionString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotBagApplicationModulePermissionLevel",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotBagApplicationModuleId = table.Column<long>(nullable: false),
                    PermissionLevel = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotBagApplicationModulePermissionLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotBagApplicationModulePermissionLevel_HotBagApplicationModule_HotBagApplicationModuleId",
                        column: x => x.HotBagApplicationModuleId,
                        principalTable: "HotBagApplicationModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotBagUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    HashedPassword = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TanentIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotBagUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotBagUser_Tenant_TanentIdId",
                        column: x => x.TanentIdId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TanentConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TanentIdId = table.Column<int>(nullable: false),
                    IsEmailConfirmationRequired = table.Column<bool>(nullable: false),
                    IsUsernameLoginIsEnabled = table.Column<bool>(nullable: false),
                    IsUseDifferentDatabase = table.Column<bool>(nullable: false),
                    IsHardPasswordIsRequired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TanentConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TanentConfiguration_Tenant_TanentIdId",
                        column: x => x.TanentIdId,
                        principalTable: "Tenant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotBagRoleApplicationModule",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<long>(nullable: false),
                    ApplicationModuleId = table.Column<long>(nullable: false),
                    ApplicationModulePermissionLevelId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotBagRoleApplicationModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotBagRoleApplicationModule_HotBagApplicationModule_ApplicationModuleId",
                        column: x => x.ApplicationModuleId,
                        principalTable: "HotBagApplicationModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotBagRoleApplicationModule_HotBagApplicationModulePermissionLevel_ApplicationModulePermissionLevelId",
                        column: x => x.ApplicationModulePermissionLevelId,
                        principalTable: "HotBagApplicationModulePermissionLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotBagRoleApplicationModule_HotBagRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "HotBagRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotBagPasswordHistoryLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    HashedPassword = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotBagPasswordHistoryLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotBagPasswordHistoryLog_HotBagUser_UserId",
                        column: x => x.UserId,
                        principalTable: "HotBagUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotBagUserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleIdId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotBagUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotBagUserRoles_HotBagRole_RoleIdId",
                        column: x => x.RoleIdId,
                        principalTable: "HotBagRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotBagUserRoles_HotBagUser_UserId",
                        column: x => x.UserId,
                        principalTable: "HotBagUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotBagUserStatusLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotBagUserStatusLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotBagUserStatusLog_HotBagUser_UserId",
                        column: x => x.UserId,
                        principalTable: "HotBagUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotBagApplicationModulePermissionLevel_HotBagApplicationModuleId",
                table: "HotBagApplicationModulePermissionLevel",
                column: "HotBagApplicationModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagPasswordHistoryLog_UserId",
                table: "HotBagPasswordHistoryLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagRoleApplicationModule_ApplicationModuleId",
                table: "HotBagRoleApplicationModule",
                column: "ApplicationModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagRoleApplicationModule_ApplicationModulePermissionLevelId",
                table: "HotBagRoleApplicationModule",
                column: "ApplicationModulePermissionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagRoleApplicationModule_RoleId",
                table: "HotBagRoleApplicationModule",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagUser_TanentIdId",
                table: "HotBagUser",
                column: "TanentIdId");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagUserRoles_RoleIdId",
                table: "HotBagUserRoles",
                column: "RoleIdId");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagUserRoles_UserId",
                table: "HotBagUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HotBagUserStatusLog_UserId",
                table: "HotBagUserStatusLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TanentConfiguration_TanentIdId",
                table: "TanentConfiguration",
                column: "TanentIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotBagPasswordHistoryLog");

            migrationBuilder.DropTable(
                name: "HotBagRoleApplicationModule");

            migrationBuilder.DropTable(
                name: "HotBagUserRoles");

            migrationBuilder.DropTable(
                name: "HotBagUserStatusLog");

            migrationBuilder.DropTable(
                name: "TanentConfiguration");

            migrationBuilder.DropTable(
                name: "HotBagApplicationModulePermissionLevel");

            migrationBuilder.DropTable(
                name: "HotBagRole");

            migrationBuilder.DropTable(
                name: "HotBagUser");

            migrationBuilder.DropTable(
                name: "HotBagApplicationModule");

            migrationBuilder.DropTable(
                name: "Tenant");
        }
    }
}
