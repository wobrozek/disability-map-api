using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace disability_map.Migrations
{
    /// <inheritdoc />
    public partial class llString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Place_User_OwnerId",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Place");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Place",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LL",
                table: "Place",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Place_User_OwnerId",
                table: "Place",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Place_User_OwnerId",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "LL",
                table: "Place");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Place",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Place",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Place",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Place_User_OwnerId",
                table: "Place",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
