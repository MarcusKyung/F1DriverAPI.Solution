using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1DriverApi.Migrations
{
    public partial class AddInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DriverName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DriverNationality = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentTeam = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DriverAge = table.Column<int>(type: "int", nullable: false),
                    RaceWins = table.Column<int>(type: "int", nullable: false),
                    Podiums = table.Column<int>(type: "int", nullable: false),
                    CareerPoints = table.Column<int>(type: "int", nullable: false),
                    WDCChampionships = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "CareerPoints", "CurrentTeam", "DriverAge", "DriverName", "DriverNationality", "Podiums", "RaceWins", "WDCChampionships" },
                values: new object[,]
                {
                    { 1, 2181, "Red Bull Racing", 25, "Max Verstappen", "Dutch", 84, 40, 2 },
                    { 2, 1318, "Red Bull Racing", 33, "Sergio Perez", "Mexican", 30, 6, 0 },
                    { 3, 2160, "Aston Martin", 41, "Fernando Alonso", "Spanish", 103, 32, 2 },
                    { 4, 4492, "Mercedes-AMG Petronas F1 Team", 38, "Lewis Hamilton", "British", 193, 103, 7 },
                    { 5, 359, "Mercedes-AMG Petronas F1 Team", 25, "George Russel", "British", 10, 1, 0 },
                    { 6, 840, "Scuderia Ferrari", 28, "Carlos Sainz Jr", "Spanish", 15, 1, 0 },
                    { 7, 910, "Scuderia Ferrari", 25, "Charles Leclerc", "Dutch", 25, 5, 0 },
                    { 8, 229, "Aston Martin", 24, "Lance Stroll", "Canadian", 3, 0, 0 },
                    { 9, 389, "Alpine", 26, "Esteban Ocon", "French", 3, 1, 0 },
                    { 10, 347, "Alpine", 27, "Pierre Gasley", "French", 3, 1, 0 },
                    { 11, 440, "McLaren F1 Team", 23, "Lando Norris", "British", 6, 0, 0 },
                    { 12, 527, "MoneyGram Haas F1 Team", 35, "Niko Hulkenberg", "German", 0, 0, 0 },
                    { 13, 5, "McLaren F1 Team", 22, "Oscar Piastri", "Australian", 0, 0, 0 },
                    { 14, 1791, "Alfa Romeo F1 Team", 33, "Valtteri Bottas", "Finnish", 67, 10, 0 },
                    { 15, 10, "Alfa Romeo F1 Team", 24, "Zho Guanyu", "Chinese", 0, 0, 0 },
                    { 16, 46, "Scuderia AlphaTauri", 23, "Yuki Tsunoda", "Japanese", 0, 0, 0 },
                    { 17, 185, "MoneyGram Haas F1 Team", 30, "Kevin Magnussen", "Danish", 1, 0, 0 },
                    { 18, 202, "Williams Racing", 27, "Alex Albon", "Thai", 2, 0, 0 },
                    { 19, 2, "Scuderia AlphaTauri", 28, "Nyck de Vries", "Dutch", 0, 0, 0 },
                    { 20, 0, "Williams Racing", 22, "Logan Sargeant", "American", 0, 0, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
