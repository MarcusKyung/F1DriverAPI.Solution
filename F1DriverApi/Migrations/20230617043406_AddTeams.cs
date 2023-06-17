using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1DriverApi.Migrations
{
    public partial class AddTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TeamName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamNationality = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamPrincipal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamBase = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamChampionships = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "TeamBase", "TeamChampionships", "TeamName", "TeamNationality", "TeamPrincipal" },
                values: new object[,]
                {
                    { 1, "Milton Keynes, United Kingdom", 5, "Red Bull Racing", "Austrian", "Christian Horner" },
                    { 2, "Silverstone, United Kingdom", 0, "Aston Martin", "British", "Mike Krack" },
                    { 3, "Brackley, United Kingdom", 9, "Mercedes-AMG Petronas F1 Team", "German", "Toto Wolff" },
                    { 4, "Maranello, Italy", 16, "Scuderia Ferrari", "Italian", "Frederic Vasseur" },
                    { 5, "Enstone, United Kingdom", 0, "Alpine", "French", "Otmar Szafnauer" },
                    { 6, "Woking, United Kingdom", 8, "McLaren F1 Team", "British", "Andrea Stella" },
                    { 7, "Kannapolis, United States", 0, "MoneyGram Haas F1 Team", "American", "Guenther Steiner" },
                    { 8, "Hinwil, Switzerland", 0, "Alfa Romeo F1 Team", "Swiss", "Alessandro Alunni Bravi" },
                    { 9, "Faenza, Italy", 0, "Scuderia AlphaTauri", "Italian", "Franz Tost" },
                    { 10, "Grove, United Kingdom", 9, "Williams Racing", "British", "James Vowles" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
