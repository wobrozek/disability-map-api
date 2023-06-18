using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace disability_map.Migrations
{
    /// <inheritdoc />
    public partial class placerelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Place",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Place_OwnerId",
                table: "Place",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Place_User_OwnerId",
                table: "Place",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Place_User_OwnerId",
                table: "Place");

            migrationBuilder.DropIndex(
                name: "IX_Place_OwnerId",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Place");
        }
    }
}
