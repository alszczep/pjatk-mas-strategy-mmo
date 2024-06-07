using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddBuildingsAndMilitaryUnit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                schema: "mas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    MaxInVillage = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryUnit",
                schema: "mas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinBarracksLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingInVillage",
                schema: "mas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    BuildingSpot = table.Column<int>(type: "int", nullable: false),
                    VillageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingInVillage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingInVillage_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "mas",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingInVillage_Village_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "mas",
                        principalTable: "Village",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingBarracksMilitaryUnit",
                schema: "mas",
                columns: table => new
                {
                    TrainableInBarracksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainableUnitsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingBarracksMilitaryUnit", x => new { x.TrainableInBarracksId, x.TrainableUnitsId });
                    table.ForeignKey(
                        name: "FK_BuildingBarracksMilitaryUnit_Building_TrainableInBarracksId",
                        column: x => x.TrainableInBarracksId,
                        principalSchema: "mas",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingBarracksMilitaryUnit_MilitaryUnit_TrainableUnitsId",
                        column: x => x.TrainableUnitsId,
                        principalSchema: "mas",
                        principalTable: "MilitaryUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingBarracksMilitaryUnit_TrainableUnitsId",
                schema: "mas",
                table: "BuildingBarracksMilitaryUnit",
                column: "TrainableUnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingInVillage_BuildingId",
                schema: "mas",
                table: "BuildingInVillage",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingInVillage_VillageId",
                schema: "mas",
                table: "BuildingInVillage",
                column: "VillageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingBarracksMilitaryUnit",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "BuildingInVillage",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "MilitaryUnit",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "Building",
                schema: "mas");
        }
    }
}
