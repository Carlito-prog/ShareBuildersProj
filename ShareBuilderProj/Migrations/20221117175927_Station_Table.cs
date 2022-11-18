using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareBuilderProj.Migrations
{
    /// <inheritdoc />
    public partial class StationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Letters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Market = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Affiliation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StationModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserModel_Stations_StationModelId",
                        column: x => x.StationModelId,
                        principalTable: "Stations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_StationModelId",
                table: "UserModel",
                column: "StationModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
