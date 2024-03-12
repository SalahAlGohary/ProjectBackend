using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Backend.Migrations
{
    /// <inheritdoc />
    public partial class MakeAddressIdOptionalInResturantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restuarant_Addresses_AddressId",
                table: "Restuarant");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Restuarant");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Restuarant",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Restuarant_Addresses_AddressId",
                table: "Restuarant",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restuarant_Addresses_AddressId",
                table: "Restuarant");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Restuarant",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Restuarant",
                type: "bit",
                nullable: false,
                defaultValue: false);



            migrationBuilder.AddForeignKey(
                name: "FK_Restuarant_Addresses_AddressId",
                table: "Restuarant",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
