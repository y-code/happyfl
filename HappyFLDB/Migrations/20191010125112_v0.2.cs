using Microsoft.EntityFrameworkCore.Migrations;

namespace HappyFL.DB.Migrations
{
    public partial class v02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "servings",
                schema: "recipe_management",
                table: "recipe",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "servings",
                schema: "recipe_management",
                table: "recipe");
        }
    }
}
