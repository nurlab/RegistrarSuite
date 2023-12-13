using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrarSuite.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Metadata");

            migrationBuilder.EnsureSchema(
                name: "Student");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShortCode = table.Column<string>(type: "TEXT", nullable: true),
                    ShortName = table.Column<string>(type: "TEXT", nullable: true),
                    NativeName = table.Column<string>(type: "TEXT", nullable: true),
                    Flag = table.Column<string>(type: "TEXT", nullable: true),
                    CurrencyCode = table.Column<string>(type: "TEXT", nullable: true),
                    CallingCode = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<string>(type: "TEXT", nullable: true),
                    Longitude = table.Column<string>(type: "TEXT", nullable: true),
                    Population = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    nationalityCode = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Countries_nationalityCode",
                        column: x => x.nationalityCode,
                        principalSchema: "Metadata",
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FamilyMembers",
                schema: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Relationship = table.Column<int>(type: "INTEGER", nullable: false),
                    nationalityCode = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<string>(type: "TEXT", nullable: true),
                    StudentId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<int>(type: "INTEGER", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMembers_Countries_nationalityCode",
                        column: x => x.nationalityCode,
                        principalSchema: "Metadata",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyMembers_Students_StudentId1",
                        column: x => x.StudentId1,
                        principalSchema: "Student",
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_nationalityCode",
                schema: "Student",
                table: "FamilyMembers",
                column: "nationalityCode");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_StudentId1",
                schema: "Student",
                table: "FamilyMembers",
                column: "StudentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_nationalityCode",
                schema: "Student",
                table: "Students",
                column: "nationalityCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyMembers",
                schema: "Student");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "Student");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Metadata");
        }
    }
}
