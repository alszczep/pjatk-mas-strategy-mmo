using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddQueues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingsQueue",
                schema: "mas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LevelAfterUpgrade = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuildingInVillageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingInVillageId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingsQueue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingsQueue_BuildingInVillage_BuildingInVillageId",
                        column: x => x.BuildingInVillageId,
                        principalSchema: "mas",
                        principalTable: "BuildingInVillage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingsQueue_BuildingInVillage_BuildingInVillageId1",
                        column: x => x.BuildingInVillageId1,
                        principalSchema: "mas",
                        principalTable: "BuildingInVillage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryUnitsInVillage",
                schema: "mas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    MilitaryUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VillageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VillageId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryUnitsInVillage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryUnitsInVillage_MilitaryUnit_MilitaryUnitId",
                        column: x => x.MilitaryUnitId,
                        principalSchema: "mas",
                        principalTable: "MilitaryUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MilitaryUnitsInVillage_Village_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "mas",
                        principalTable: "Village",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MilitaryUnitsInVillage_Village_VillageId1",
                        column: x => x.VillageId1,
                        principalSchema: "mas",
                        principalTable: "Village",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MilitaryUnitsQueue",
                schema: "mas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MilitaryUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VillageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VillageId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryUnitsQueue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryUnitsQueue_MilitaryUnit_MilitaryUnitId",
                        column: x => x.MilitaryUnitId,
                        principalSchema: "mas",
                        principalTable: "MilitaryUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MilitaryUnitsQueue_Village_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "mas",
                        principalTable: "Village",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MilitaryUnitsQueue_Village_VillageId1",
                        column: x => x.VillageId1,
                        principalSchema: "mas",
                        principalTable: "Village",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingsQueue_BuildingInVillageId",
                schema: "mas",
                table: "BuildingsQueue",
                column: "BuildingInVillageId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingsQueue_BuildingInVillageId1",
                schema: "mas",
                table: "BuildingsQueue",
                column: "BuildingInVillageId1");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnitsInVillage_MilitaryUnitId",
                schema: "mas",
                table: "MilitaryUnitsInVillage",
                column: "MilitaryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnitsInVillage_VillageId",
                schema: "mas",
                table: "MilitaryUnitsInVillage",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnitsInVillage_VillageId1",
                schema: "mas",
                table: "MilitaryUnitsInVillage",
                column: "VillageId1");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnitsQueue_MilitaryUnitId",
                schema: "mas",
                table: "MilitaryUnitsQueue",
                column: "MilitaryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnitsQueue_VillageId",
                schema: "mas",
                table: "MilitaryUnitsQueue",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnitsQueue_VillageId1",
                schema: "mas",
                table: "MilitaryUnitsQueue",
                column: "VillageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Village_Id",
                schema: "mas",
                table: "Resources",
                column: "Id",
                principalSchema: "mas",
                principalTable: "Village",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Village_Id",
                schema: "mas",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "BuildingsQueue",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "MilitaryUnitsInVillage",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "MilitaryUnitsQueue",
                schema: "mas");
        }
    }
}
