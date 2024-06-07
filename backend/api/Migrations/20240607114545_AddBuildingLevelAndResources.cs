using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddBuildingLevelAndResources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingType",
                schema: "mas",
                table: "Building");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                schema: "mas",
                table: "Building",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Resources",
                schema: "mas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Wood = table.Column<int>(type: "int", nullable: false),
                    Iron = table.Column<int>(type: "int", nullable: false),
                    Wheat = table.Column<int>(type: "int", nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingLevel",
                schema: "mas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    BuildingTimeInSeconds = table.Column<int>(type: "int", nullable: false),
                    TrainingTimeShortenedInSeconds = table.Column<int>(type: "int", nullable: true),
                    ResourcesCostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourcesProductionPerMinuteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingLevel_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "mas",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingLevel_Resources_ResourcesCostId",
                        column: x => x.ResourcesCostId,
                        principalSchema: "mas",
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingLevel_Resources_ResourcesProductionPerMinuteId",
                        column: x => x.ResourcesProductionPerMinuteId,
                        principalSchema: "mas",
                        principalTable: "Resources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingLevel_BuildingId",
                schema: "mas",
                table: "BuildingLevel",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingLevel_ResourcesCostId",
                schema: "mas",
                table: "BuildingLevel",
                column: "ResourcesCostId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingLevel_ResourcesProductionPerMinuteId",
                schema: "mas",
                table: "BuildingLevel",
                column: "ResourcesProductionPerMinuteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingLevel",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "Resources",
                schema: "mas");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "mas",
                table: "Building");

            migrationBuilder.AddColumn<string>(
                name: "BuildingType",
                schema: "mas",
                table: "Building",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");
        }
    }
}
