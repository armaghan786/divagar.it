using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantManagement.Migrations
{
    public partial class AddOrderID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemNameEnglish",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNameFrance",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNameGermany",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNameSpanish",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemPriceEnglish",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemPriceFrance",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemPriceGermany",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemPriceSpanish",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubtextEnglish",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubtextFrance",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubtextGermany",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubtextSpanish",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryNameEnglish",
                table: "FoodCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryNameFrance",
                table: "FoodCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryNameGermany",
                table: "FoodCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryNameSpanish",
                table: "FoodCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "FoodCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemNameEnglish",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ItemNameFrance",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ItemNameGermany",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ItemNameSpanish",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ItemPriceEnglish",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ItemPriceFrance",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ItemPriceGermany",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "ItemPriceSpanish",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "SubtextEnglish",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "SubtextFrance",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "SubtextGermany",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "SubtextSpanish",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "CategoryNameEnglish",
                table: "FoodCategories");

            migrationBuilder.DropColumn(
                name: "CategoryNameFrance",
                table: "FoodCategories");

            migrationBuilder.DropColumn(
                name: "CategoryNameGermany",
                table: "FoodCategories");

            migrationBuilder.DropColumn(
                name: "CategoryNameSpanish",
                table: "FoodCategories");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "FoodCategories");
        }
    }
}
