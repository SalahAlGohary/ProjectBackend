using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRecipeIdToInt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Favorites_Recipe_RecipeId",
            //    table: "Favorites");

            //migrationBuilder.DropIndex(
            //    name: "IX_Favorites_RecipeId",
            //    table: "Favorites");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Favorites");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Favorites",
                type: "int",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_RecipeId",
                table: "Favorites",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Recipe_RecipeId",
                table: "Favorites",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
            onDelete: ReferentialAction.NoAction);

            //Id = table.Column<int>(type: "int", nullable: false)
            //           .Annotation("SqlServer:Identity", "1, 1"),

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
