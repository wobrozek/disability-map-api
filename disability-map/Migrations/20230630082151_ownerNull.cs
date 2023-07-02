using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace disability_map.Migrations
{
    /// <inheritdoc />
    public partial class ownerNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Place_User_OwnerId",
                table: "Place");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Place",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Place",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Place_User_OwnerId",
                table: "Place",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
