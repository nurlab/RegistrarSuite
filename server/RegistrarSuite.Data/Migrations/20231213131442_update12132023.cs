using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrarSuite.Data.Migrations
{
    /// <inheritdoc />
    public partial class update12132023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Countries_NationalityId",
                schema: "Student",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Countries_NationalityId",
                schema: "Student",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_NationalityId",
                schema: "Student",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMembers_NationalityId",
                schema: "Student",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                schema: "Student",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                schema: "Student",
                table: "FamilyMembers");

            migrationBuilder.AddColumn<string>(
                name: "NationalityCode",
                schema: "Student",
                table: "Students",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalityCode",
                schema: "Student",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                schema: "Student",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                schema: "Student",
                table: "FamilyMembers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_NationalityId",
                schema: "Student",
                table: "Students",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_NationalityId",
                schema: "Student",
                table: "FamilyMembers",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Countries_NationalityId",
                schema: "Student",
                table: "FamilyMembers",
                column: "NationalityId",
                principalSchema: "Metadata",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Countries_NationalityId",
                schema: "Student",
                table: "Students",
                column: "NationalityId",
                principalSchema: "Metadata",
                principalTable: "Countries",
                principalColumn: "Id");
        }
    }
}
