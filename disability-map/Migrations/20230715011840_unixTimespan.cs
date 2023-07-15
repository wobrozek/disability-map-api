using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace disability_map.Migrations
{
    /// <inheritdoc />
    public partial class unixTimespan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnixTimestamp",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnixTimestamp",
                table: "Reservations");
        }
    }
}
