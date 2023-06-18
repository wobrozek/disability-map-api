using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace disability_map.Migrations
{
    /// <inheritdoc />
    public partial class relations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreUser_Score_LikesPlaceId",
                table: "ScoreUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreUser_User_LikesId",
                table: "ScoreUser");

            migrationBuilder.RenameColumn(
                name: "LikesPlaceId",
                table: "ScoreUser",
                newName: "DisLikesPlaceId");

            migrationBuilder.RenameColumn(
                name: "LikesId",
                table: "ScoreUser",
                newName: "DisLikesId");

            migrationBuilder.RenameIndex(
                name: "IX_ScoreUser_LikesPlaceId",
                table: "ScoreUser",
                newName: "IX_ScoreUser_DisLikesPlaceId");

            migrationBuilder.CreateTable(
                name: "ScoreUser1",
                columns: table => new
                {
                    LikesId = table.Column<int>(type: "int", nullable: false),
                    LikesPlaceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreUser1", x => new { x.LikesId, x.LikesPlaceId });
                    table.ForeignKey(
                        name: "FK_ScoreUser1_Score_LikesPlaceId",
                        column: x => x.LikesPlaceId,
                        principalTable: "Score",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreUser1_User_LikesId",
                        column: x => x.LikesId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScoreUser1_LikesPlaceId",
                table: "ScoreUser1",
                column: "LikesPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreUser_Score_DisLikesPlaceId",
                table: "ScoreUser",
                column: "DisLikesPlaceId",
                principalTable: "Score",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreUser_User_DisLikesId",
                table: "ScoreUser",
                column: "DisLikesId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreUser_Score_DisLikesPlaceId",
                table: "ScoreUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreUser_User_DisLikesId",
                table: "ScoreUser");

            migrationBuilder.DropTable(
                name: "ScoreUser1");

            migrationBuilder.RenameColumn(
                name: "DisLikesPlaceId",
                table: "ScoreUser",
                newName: "LikesPlaceId");

            migrationBuilder.RenameColumn(
                name: "DisLikesId",
                table: "ScoreUser",
                newName: "LikesId");

            migrationBuilder.RenameIndex(
                name: "IX_ScoreUser_DisLikesPlaceId",
                table: "ScoreUser",
                newName: "IX_ScoreUser_LikesPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreUser_Score_LikesPlaceId",
                table: "ScoreUser",
                column: "LikesPlaceId",
                principalTable: "Score",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreUser_User_LikesId",
                table: "ScoreUser",
                column: "LikesId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
