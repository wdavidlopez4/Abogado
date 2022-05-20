using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abogado.Infrastructure.Migrations
{
    public partial class AbogadoMigration1 : Migration
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trial = table.Column<int>(type: "int", nullable: false),
                    DivorceForm = table.Column<int>(type: "int", nullable: false),
                    DivorceMechanism = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Cases_CaseId",
                        column: x => x.CaseId,
                        principalSchema: "ABOGADO",
                        principalTable: "Cases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cases_Files_FileId",
                        column: x => x.FileId,
                        principalSchema: "ABOGADO",
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMeetings",
                schema: "ABOGADO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeetingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMeetings_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalSchema: "ABOGADO",
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMeetings_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ABOGADO",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCases",
                schema: "ABOGADO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCases_Cases_CaseId",
                        column: x => x.CaseId,
                        principalSchema: "ABOGADO",
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCases_Users_UserId",
                        column: x => x.UserId,
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
                name: "IX_UserCases_CaseId",
                schema: "ABOGADO",
                table: "UserCases",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCases_UserId",
                schema: "ABOGADO",
                table: "UserCases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeetings_MeetingId",
                schema: "ABOGADO",
                table: "UserMeetings",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeetings_UserId",
                schema: "ABOGADO",
                table: "UserMeetings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCases",
                schema: "ABOGADO");

            migrationBuilder.DropTable(
                name: "UserMeetings",
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
