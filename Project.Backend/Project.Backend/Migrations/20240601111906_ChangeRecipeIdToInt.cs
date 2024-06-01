using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRecipeIdToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Recipe_RecipeId1",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_RecipeId1",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "RecipeId1",
                table: "Favorites");



            //migrationBuilder.CreateIndex(
            //    name: "IX_Favorites_RecipeId",
            //    table: "Favorites",
            //    column: "RecipeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Favorites_Recipe_RecipeId",
            //    table: "Favorites",
            //    column: "RecipeId",
            //    principalTable: "Recipe",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Recipe_RecipeId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_RecipeId",
                table: "Favorites");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "Favorites",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId1",
                table: "Favorites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_RecipeId1",
                table: "Favorites",
                column: "RecipeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Recipe_RecipeId1",
                table: "Favorites",
                column: "RecipeId1",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
