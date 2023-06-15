using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1DriverApi.Migrations
{
    public partial class AddInitialDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 7,
                column: "DriverNationality",
                value: "Monegasque");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drivers",
                keyColumn: "DriverId",
                keyValue: 7,
                column: "DriverNationality",
                value: "Dutch");
        }
    }
}
