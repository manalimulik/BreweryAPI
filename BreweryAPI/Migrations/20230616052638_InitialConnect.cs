using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BreweryAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialConnect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblBar",
                columns: table => new
                {
                    BarId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BarName = table.Column<string>(type: "TEXT", nullable: false),
                    BarAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBar", x => x.BarId);
                });

            migrationBuilder.CreateTable(
                name: "tblBarAndBeerInfo",
                columns: table => new
                {
                    BarAndBeerInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BarId = table.Column<int>(type: "INTEGER", nullable: false),
                    BeerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBarAndBeerInfo", x => x.BarAndBeerInfoId);
                });

            migrationBuilder.CreateTable(
                name: "tblBeer",
                columns: table => new
                {
                    BeerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeerName = table.Column<string>(type: "TEXT", nullable: false),
                    PercentageAlchoholByVolume = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBeer", x => x.BeerId);
                });

            migrationBuilder.CreateTable(
                name: "tblBrewery",
                columns: table => new
                {
                    BreweryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BreweryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBrewery", x => x.BreweryId);
                });

            migrationBuilder.CreateTable(
                name: "tblBreweryAndBeerInfo",
                columns: table => new
                {
                    BreweryAndBeerInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BreweryId = table.Column<int>(type: "INTEGER", nullable: false),
                    BeerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBreweryAndBeerInfo", x => x.BreweryAndBeerInfoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblBar");

            migrationBuilder.DropTable(
                name: "tblBarAndBeerInfo");

            migrationBuilder.DropTable(
                name: "tblBeer");

            migrationBuilder.DropTable(
                name: "tblBrewery");

            migrationBuilder.DropTable(
                name: "tblBreweryAndBeerInfo");
        }
    }
}
