using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TouchCloudBackEnd.Migrations
{
    public partial class migr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    IdAction = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    NameAction = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    IdGroup = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    DescriptionGroup = table.Column<string>(nullable: true),
                    NameGroup = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.IdGroup);
                });

            migrationBuilder.CreateTable(
                name: "RoleUsers",
                columns: table => new
                {
                    IdRoleUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    NameRoleUser = table.Column<string>(nullable: true),
                    NumberRoleUser = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUsers", x => x.IdRoleUser);
                });

            migrationBuilder.CreateTable(
                name: "ActionGroup",
                columns: table => new
                {
                    IdAction = table.Column<int>(nullable: false),
                    IdGroup = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionGroup", x => new { x.IdAction, x.IdGroup });
                    table.ForeignKey(
                        name: "FK_ActionGroup_Actions_IdAction",
                        column: x => x.IdAction,
                        principalTable: "Actions",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionGroup_Groups_IdGroup",
                        column: x => x.IdGroup,
                        principalTable: "Groups",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthdateUser = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    EmailUser = table.Column<string>(nullable: true),
                    HiddenInfos = table.Column<string>(nullable: true),
                    PasswordUser = table.Column<string>(maxLength: 50, nullable: false),
                    PseudoUser = table.Column<string>(maxLength: 50, nullable: true),
                    RoleUser_Id = table.Column<int>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_RoleUsers_RoleUser_Id",
                        column: x => x.RoleUser_Id,
                        principalTable: "RoleUsers",
                        principalColumn: "IdRoleUser",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "User_Group",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false),
                    IdGroup = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Group", x => new { x.IdUser, x.IdGroup });
                    table.ForeignKey(
                        name: "FK_User_Group_Groups_IdGroup",
                        column: x => x.IdGroup,
                        principalTable: "Groups",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Group_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionGroup_IdAction",
                table: "ActionGroup",
                column: "IdAction");

            migrationBuilder.CreateIndex(
                name: "IX_ActionGroup_IdGroup",
                table: "ActionGroup",
                column: "IdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleUser_Id",
                table: "Users",
                column: "RoleUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Group_IdGroup",
                table: "User_Group",
                column: "IdGroup");

            migrationBuilder.CreateIndex(
                name: "IX_User_Group_IdUser",
                table: "User_Group",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionGroup");

            migrationBuilder.DropTable(
                name: "User_Group");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "RoleUsers");
        }
    }
}
