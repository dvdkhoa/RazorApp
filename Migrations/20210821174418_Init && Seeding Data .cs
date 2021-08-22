using System;
using Bogus;
using CRUD_DbContext_RazorApp.models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_DbContext_RazorApp.Migrations
{
    public partial class InitSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            Bogus.Randomizer.Seed = new Random(8675309);
            var fakerArticle = new Faker<Article>();
            fakerArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5,5));
            fakerArticle.RuleFor(a => a.DateCreated, f => f.Date.Between(new DateTime(2021,1,1),new DateTime(2021,8,22)));
            fakerArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 4));

            for (int i = 0; i < 150; i++)
            {
                var article = fakerArticle.Generate();

                migrationBuilder.InsertData(
                    table: "Articles",
                    columns: new string[] { "Title", "DateCreated", "Content" },
                    values: new object[] { article.Title, article.DateCreated, article.Content });
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
