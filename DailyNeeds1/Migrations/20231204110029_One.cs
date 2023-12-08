using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyNeeds1.Migrations
{
    /// <inheritdoc />
    public partial class One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.CreateIndex(
                name: "IX_products_CityId",
                table: "products",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_products_LocId",
                table: "products",
                column: "LocId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Cities_CityId",
                table: "products",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_products_Locations_LocId",
                table: "products",
                column: "LocId",
                principalTable: "Locations",
                principalColumn: "LocId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Cities_CityId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_Locations_LocId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_CityId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_LocId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "LocId",
                table: "products");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "logins",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "logins",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldMaxLength: 8);
        }
    }
}
