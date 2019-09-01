using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HappyFL.DB.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "recipe_management");

            migrationBuilder.CreateTable(
                name: "dish",
                schema: "recipe_management",
                columns: table => new
                {
                    dish_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true),
                    cuisine = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dish", x => x.dish_id);
                });

            migrationBuilder.CreateTable(
                name: "ingredient_section",
                schema: "recipe_management",
                columns: table => new
                {
                    ingredient_section_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient_section", x => x.ingredient_section_id);
                });

            migrationBuilder.CreateTable(
                name: "recipe",
                schema: "recipe_management",
                columns: table => new
                {
                    recipe_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true),
                    url_of_base = table.Column<string>(nullable: true),
                    dish_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe", x => x.recipe_id);
                    table.ForeignKey(
                        name: "FK_recipe_dish_dish_id",
                        column: x => x.dish_id,
                        principalSchema: "recipe_management",
                        principalTable: "dish",
                        principalColumn: "dish_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ingredient",
                schema: "recipe_management",
                columns: table => new
                {
                    ingredient_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    name = table.Column<string>(nullable: true),
                    amount = table.Column<float>(nullable: true),
                    unit = table.Column<string>(nullable: true),
                    note = table.Column<string>(nullable: true),
                    recipe_id = table.Column<long>(nullable: true),
                    ingredient_section_id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient", x => x.ingredient_id);
                    table.ForeignKey(
                        name: "FK_ingredient_ingredient_section_ingredient_section_id",
                        column: x => x.ingredient_section_id,
                        principalSchema: "recipe_management",
                        principalTable: "ingredient_section",
                        principalColumn: "ingredient_section_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ingredient_recipe_recipe_id",
                        column: x => x.recipe_id,
                        principalSchema: "recipe_management",
                        principalTable: "recipe",
                        principalColumn: "recipe_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_ingredient_section_id",
                schema: "recipe_management",
                table: "ingredient",
                column: "ingredient_section_id");

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_recipe_id",
                schema: "recipe_management",
                table: "ingredient",
                column: "recipe_id");

            migrationBuilder.CreateIndex(
                name: "IX_recipe_dish_id",
                schema: "recipe_management",
                table: "recipe",
                column: "dish_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredient",
                schema: "recipe_management");

            migrationBuilder.DropTable(
                name: "ingredient_section",
                schema: "recipe_management");

            migrationBuilder.DropTable(
                name: "recipe",
                schema: "recipe_management");

            migrationBuilder.DropTable(
                name: "dish",
                schema: "recipe_management");
        }
    }
}
