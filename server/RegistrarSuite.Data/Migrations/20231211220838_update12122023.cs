using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrarSuite.Data.Migrations
{
    /// <inheritdoc />
    public partial class update12122023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Metadata",
                table: "Countries",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Metadata",
                table: "Countries");
        }
    }
}
