using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HappyFL.DB.Migrations
{
    public partial class v01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cuisine",
                schema: "recipe_management",
                table: "dish");

            migrationBuilder.CreateTable(
                name: "dish_tag",
                schema: "recipe_management",
                columns: table => new
                {
                    dish_tag_id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DishId = table.Column<long>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dish_tag", x => x.dish_tag_id);
                    table.ForeignKey(
                        name: "FK_dish_tag_dish_DishId",
                        column: x => x.DishId,
                        principalSchema: "recipe_management",
                        principalTable: "dish",
                        principalColumn: "dish_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dish_tag_DishId",
                schema: "recipe_management",
                table: "dish_tag",
                column: "DishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dish_tag",
                schema: "recipe_management");

            migrationBuilder.AddColumn<string>(
                name: "cuisine",
                schema: "recipe_management",
                table: "dish",
                nullable: true);
        }
    }
}
