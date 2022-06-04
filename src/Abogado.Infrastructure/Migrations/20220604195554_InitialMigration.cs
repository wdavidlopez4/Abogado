using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abogado.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ABOGADO");

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "ABOGADO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                schema: "ABOGADO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "ABOGADO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncriptPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                schema: "ABOGADO",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    CaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trial = table.Column<int>(type: "int", nullable: false),
                    DivorceForm = table.Column<int>(type: "int", nullable: false),
                    DivorceMechanism = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<string>(type: "varchar(36)", nullable: false),
                    CaseId = table.Column<string>(type: "varchar(36)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPrincipalCase = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Cases_CaseId",
                        column: x => x.CaseId,
                        principalSchema: "ABOGADO",
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cases_Files_FileId",
                        column: x => x.FileId,
                        principalSchema: "ABOGADO",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingUser",
                schema: "ABOGADO",
                columns: table => new
                {
                    MeetingsId = table.Column<string>(type: "varchar(36)", nullable: false),
                    UsersId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingUser", x => new { x.MeetingsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_MeetingUser_Meetings_MeetingsId",
                        column: x => x.MeetingsId,
                        principalSchema: "ABOGADO",
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "ABOGADO",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseUser",
                schema: "ABOGADO",
                columns: table => new
                {
                    CasesId = table.Column<string>(type: "varchar(36)", nullable: false),
                    UsersId = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseUser", x => new { x.CasesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CaseUser_Cases_CasesId",
                        column: x => x.CasesId,
                        principalSchema: "ABOGADO",
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaseUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "ABOGADO",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseId",
                schema: "ABOGADO",
                table: "Cases",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_FileId",
                schema: "ABOGADO",
                table: "Cases",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseUser_UsersId",
                schema: "ABOGADO",
                table: "CaseUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingUser_UsersId",
                schema: "ABOGADO",
                table: "MeetingUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseUser",
                schema: "ABOGADO");

            migrationBuilder.DropTable(
                name: "MeetingUser",
                schema: "ABOGADO");

            migrationBuilder.DropTable(
                name: "Cases",
                schema: "ABOGADO");

            migrationBuilder.DropTable(
                name: "Meetings",
                schema: "ABOGADO");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "ABOGADO");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "ABOGADO");
        }
    }
}
