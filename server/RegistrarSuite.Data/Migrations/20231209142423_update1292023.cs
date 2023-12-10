using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrarSuite.Data.Migrations
{
    /// <inheritdoc />
    public partial class update1292023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Countries_NationalityId",
                schema: "Student",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Students_StudentId1",
                schema: "Student",
                table: "FamilyMembers");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMembers_StudentId1",
                schema: "Student",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                schema: "Student",
                table: "FamilyMembers");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Student",
                table: "FamilyMembers",
                newName: "LastName");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                schema: "Student",
                table: "FamilyMembers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NationalityId",
                schema: "Student",
                table: "FamilyMembers",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "Student",
                table: "FamilyMembers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Student",
                table: "FamilyMembers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_StudentId",
                schema: "Student",
                table: "FamilyMembers",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Countries_NationalityId",
                schema: "Student",
                table: "FamilyMembers",
                column: "NationalityId",
                principalSchema: "Metadata",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Students_StudentId",
                schema: "Student",
                table: "FamilyMembers",
                column: "StudentId",
                principalSchema: "Student",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Countries_NationalityId",
                schema: "Student",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Students_StudentId",
                schema: "Student",
                table: "FamilyMembers");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMembers_StudentId",
                schema: "Student",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "Student",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Student",
                table: "FamilyMembers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "Student",
                table: "FamilyMembers",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                schema: "Student",
                table: "FamilyMembers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NationalityId",
                schema: "Student",
                table: "FamilyMembers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                schema: "Student",
                table: "FamilyMembers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_StudentId1",
                schema: "Student",
                table: "FamilyMembers",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Countries_NationalityId",
                schema: "Student",
                table: "FamilyMembers",
                column: "NationalityId",
                principalSchema: "Metadata",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Students_StudentId1",
                schema: "Student",
                table: "FamilyMembers",
                column: "StudentId1",
                principalSchema: "Student",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
