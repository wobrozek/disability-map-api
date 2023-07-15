using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace disability_map.Migrations
{
    /// <inheritdoc />
    public partial class seq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UnixTimestamp",
                table: "Reservations");

            migrationBuilder.AddColumn<long>(
                name: "Seq",
                table: "Reservations",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seq",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UnixTimestamp",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
