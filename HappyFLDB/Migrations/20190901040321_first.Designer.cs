﻿// <auto-generated />
using System;
using HappyFL.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HappyFL.DB.Migrations
{
    [DbContext(typeof(HappyFLDbContext))]
    [Migration("20190901040321_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HappyFL.DB.RecipeManagement.Dish", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("dish_id");

                    b.Property<string>("Cuisine")
                        .HasColumnName("cuisine");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("dish","recipe_management");
                });

            modelBuilder.Entity("HappyFL.DB.RecipeManagement.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ingredient_id");

                    b.Property<float?>("Amount")
                        .HasColumnName("amount");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Note")
                        .HasColumnName("note");

                    b.Property<string>("Unit")
                        .HasColumnName("unit");

                    b.Property<long?>("ingredient_section_id");

                    b.Property<long?>("recipe_id");

                    b.HasKey("Id");

                    b.HasIndex("ingredient_section_id");

                    b.HasIndex("recipe_id");

                    b.ToTable("ingredient","recipe_management");
                });

            modelBuilder.Entity("HappyFL.DB.RecipeManagement.IngredientSection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ingredient_section_id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("ingredient_section","recipe_management");
                });

            modelBuilder.Entity("HappyFL.DB.RecipeManagement.Recipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("recipe_id");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("UrlofBase")
                        .HasColumnName("url_of_base");

                    b.Property<long?>("dish_id");

                    b.HasKey("Id");

                    b.HasIndex("dish_id");

                    b.ToTable("recipe","recipe_management");
                });

            modelBuilder.Entity("HappyFL.DB.RecipeManagement.Ingredient", b =>
                {
                    b.HasOne("HappyFL.DB.RecipeManagement.IngredientSection", "Section")
                        .WithMany("Ingredients")
                        .HasForeignKey("ingredient_section_id");

                    b.HasOne("HappyFL.DB.RecipeManagement.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("recipe_id");
                });

            modelBuilder.Entity("HappyFL.DB.RecipeManagement.Recipe", b =>
                {
                    b.HasOne("HappyFL.DB.RecipeManagement.Dish", "Dish")
                        .WithMany("Recipes")
                        .HasForeignKey("dish_id");
                });
#pragma warning restore 612, 618
        }
    }
}
