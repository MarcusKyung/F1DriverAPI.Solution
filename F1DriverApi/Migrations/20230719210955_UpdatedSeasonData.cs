using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1DriverApi.Migrations
{
    public partial class UpdatedSeasonData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "currentSeasonPoints",
                table: "Drivers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 1,
                columns: new[] { "CareerPoints", "Podiums", "RaceWins", "currentSeasonPoints" },
                values: new object[] { 2266, 87, 43, 255 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 2,
                columns: new[] { "CareerPoints", "Podiums", "currentSeasonPoints" },
                values: new object[] { 1357, 31, 156 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 3,
                columns: new[] { "CareerPoints", "Podiums", "currentSeasonPoints" },
                values: new object[] { 2198, 104, 137 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 4,
                columns: new[] { "CareerPoints", "Podiums", "currentSeasonPoints" },
                values: new object[] { 4526, 195, 121 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 5,
                columns: new[] { "CareerPoints", "currentSeasonPoints" },
                values: new object[] { 376, 82 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 6,
                columns: new[] { "CareerPoints", "currentSeasonPoints" },
                values: new object[] { 865, 83 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 7,
                columns: new[] { "CareerPoints", "Podiums", "currentSeasonPoints" },
                values: new object[] { 940, 26, 74 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 8,
                columns: new[] { "CareerPoints", "currentSeasonPoints" },
                values: new object[] { 238, 44 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 9,
                columns: new[] { "CareerPoints", "currentSeasonPoints" },
                values: new object[] { 395, 31 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 10,
                columns: new[] { "CareerPoints", "currentSeasonPoints" },
                values: new object[] { 348, 16 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 11,
                columns: new[] { "CareerPoints", "Podiums", "currentSeasonPoints" },
                values: new object[] { 470, 7, 42 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 12,
                columns: new[] { "CareerPoints", "currentSeasonPoints" },
                values: new object[] { 530, 9 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 13,
                column: "currentSeasonPoints",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 14,
                columns: new[] { "CareerPoints", "currentSeasonPoints" },
                values: new object[] { 1792, 5 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 15,
                column: "currentSeasonPoints",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 16,
                column: "currentSeasonPoints",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 17,
                column: "currentSeasonPoints",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 18,
                columns: new[] { "CareerPoints", "currentSeasonPoints" },
                values: new object[] { 212, 11 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 19,
                column: "CurrentTeam",
                value: "None");

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "CareerPoints", "CurrentTeam", "DriverAge", "DriverName", "DriverNationality", "Podiums", "RaceWins", "WDCChampionships", "currentSeasonPoints" },
                values: new object[] { 21, 1311, "Scuderia AlphaTauri", 34, "Daniel Riccardio", "Australian", 32, 8, 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 21);

            migrationBuilder.DropColumn(
                name: "currentSeasonPoints",
                table: "Drivers");

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 1,
                columns: new[] { "CareerPoints", "Podiums", "RaceWins" },
                values: new object[] { 2181, 84, 40 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 2,
                columns: new[] { "CareerPoints", "Podiums" },
                values: new object[] { 1318, 30 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 3,
                columns: new[] { "CareerPoints", "Podiums" },
                values: new object[] { 2160, 103 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 4,
                columns: new[] { "CareerPoints", "Podiums" },
                values: new object[] { 4492, 193 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 5,
                column: "CareerPoints",
                value: 359);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 6,
                column: "CareerPoints",
                value: 840);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 7,
                columns: new[] { "CareerPoints", "Podiums" },
                values: new object[] { 910, 25 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 8,
                column: "CareerPoints",
                value: 229);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 9,
                column: "CareerPoints",
                value: 389);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 10,
                column: "CareerPoints",
                value: 347);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 11,
                columns: new[] { "CareerPoints", "Podiums" },
                values: new object[] { 440, 6 });

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 12,
                column: "CareerPoints",
                value: 527);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 14,
                column: "CareerPoints",
                value: 1791);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 18,
                column: "CareerPoints",
                value: 202);

            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 19,
                column: "CurrentTeam",
                value: "Scuderia AlphaTauri");
        }
    }
}
