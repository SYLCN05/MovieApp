using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class MovieTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Poster_Link = table.Column<string>(type: "longtext", nullable: false),
                    Series_Title = table.Column<string>(type: "longtext", nullable: false),
                    Released_Year = table.Column<int>(type: "int", nullable: false),
                    Certificate = table.Column<string>(type: "longtext", nullable: false),
                    Runtime = table.Column<string>(type: "longtext", nullable: false),
                    Genre = table.Column<string>(type: "longtext", nullable: false),
                    IMDB_Rating = table.Column<int>(type: "int", nullable: false),
                    Overview = table.Column<string>(type: "longtext", nullable: false),
                    Meta_score = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "longtext", nullable: false),
                    Star1 = table.Column<string>(type: "longtext", nullable: false),
                    Star2 = table.Column<string>(type: "longtext", nullable: false),
                    Star3 = table.Column<string>(type: "longtext", nullable: false),
                    Star4 = table.Column<string>(type: "longtext", nullable: false),
                    No_Of_Votes = table.Column<int>(type: "int", nullable: false),
                    Gross = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
