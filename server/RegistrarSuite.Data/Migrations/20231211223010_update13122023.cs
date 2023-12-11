using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrarSuite.Data.Migrations
{
    /// <inheritdoc />
    public partial class update13122023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CallingCode",
                schema: "Metadata",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                schema: "Metadata",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Flag",
                schema: "Metadata",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Latitude",
                schema: "Metadata",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Longitude",
                schema: "Metadata",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "NativeName",
                schema: "Metadata",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Population",
                schema: "Metadata",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ShortCode",
                schema: "Metadata",
                table: "Countries");

            migrationBuilder.RenameColumn(
                name: "ShortName",
                schema: "Metadata",
                table: "Countries",
                newName: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Code",
                schema: "Metadata",
                table: "Countries",
                newName: "ShortName");

            migrationBuilder.AddColumn<string>(
                name: "CallingCode",
                schema: "Metadata",
                table: "Countries",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                schema: "Metadata",
                table: "Countries",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Flag",
                schema: "Metadata",
                table: "Countries",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                schema: "Metadata",
                table: "Countries",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                schema: "Metadata",
                table: "Countries",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NativeName",
                schema: "Metadata",
                table: "Countries",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Population",
                schema: "Metadata",
                table: "Countries",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ShortCode",
                schema: "Metadata",
                table: "Countries",
                type: "TEXT",
                nullable: true);
        }
    }
}
