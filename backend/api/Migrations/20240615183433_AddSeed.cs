using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assistant_User_Id",
                schema: "mas",
                table: "Assistant");

            migrationBuilder.DropForeignKey(
                name: "FK_Assistant_Village_Id",
                schema: "mas",
                table: "Assistant");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Village_Id",
                schema: "mas",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "BuildingBarracksMilitaryUnit",
                schema: "mas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assistant",
                schema: "mas",
                table: "Assistant");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "mas",
                table: "Assistant",
                newName: "VillageId");

            migrationBuilder.AddColumn<Guid>(
                name: "AvailableResourcesId",
                schema: "mas",
                table: "Village",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingCostId",
                schema: "mas",
                table: "MilitaryUnit",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "TrainingTimeInSeconds",
                schema: "mas",
                table: "MilitaryUnit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "mas",
                table: "Assistant",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assistant",
                schema: "mas",
                table: "Assistant",
                columns: new[] { "UserId", "VillageId" });

            migrationBuilder.CreateTable(
                name: "MilitaryUnitTrainableInBarracks",
                schema: "mas",
                columns: table => new
                {
                    BuildingBarracksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MilitaryUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryUnitTrainableInBarracks", x => new { x.BuildingBarracksId, x.MilitaryUnitId });
                    table.ForeignKey(
                        name: "FK_MilitaryUnitTrainableInBarracks_Building_BuildingBarracksId",
                        column: x => x.BuildingBarracksId,
                        principalSchema: "mas",
                        principalTable: "Building",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MilitaryUnitTrainableInBarracks_MilitaryUnit_MilitaryUnitId",
                        column: x => x.MilitaryUnitId,
                        principalSchema: "mas",
                        principalTable: "MilitaryUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "mas",
                table: "Building",
                columns: new[] { "Id", "ImageUrl", "MaxInVillage", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "http://localhost:4200/buildings/gold_mine.svg", 2, "Gold mine", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "http://localhost:4200/buildings/iron_mine.svg", 2, "Iron mine", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "http://localhost:4200/buildings/farm.svg", 2, "Farm", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "http://localhost:4200/buildings/woodcutters_hut.svg", 2, "Woodcutter's hut", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "http://localhost:4200/buildings/barracks.svg", 1, "Barracks", 0 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "http://localhost:4200/buildings/fortress.svg", 1, "University of military tactics", 0 }
                });

            migrationBuilder.InsertData(
                schema: "mas",
                table: "Location",
                columns: new[] { "PositionX", "PositionY", "AllResourcesProductionPercentageLoss", "GoldProductionBonus", "MilitaryUnitsDefensePercentageBonus" },
                values: new object[,]
                {
                    { 0, 0, null, null, 0 },
                    { 0, 1, null, 10, 10 },
                    { 1, 0, 10, null, 20 },
                    { 1, 1, 10, 10, 0 },
                    { 2, 0, null, 20, 0 },
                    { 2, 1, 20, null, 20 },
                    { 2, 2, null, null, 10 }
                });

            migrationBuilder.InsertData(
                schema: "mas",
                table: "Resources",
                columns: new[] { "Id", "Gold", "Iron", "Wheat", "Wood" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 10, 20, 0, 100 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 1, 0, 0, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 15, 25, 0, 120 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 2, 0, 0, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 20, 10, 0, 100 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 0, 1, 0, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 25, 15, 0, 120 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 0, 2, 0, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 0, 0, 5, 120 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), 0, 0, 1, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000011"), 0, 0, 10, 150 },
                    { new Guid("00000000-0000-0000-0000-000000000012"), 0, 0, 2, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), 8, 10, 15, 60 },
                    { new Guid("00000000-0000-0000-0000-000000000014"), 0, 0, 0, 1 },
                    { new Guid("00000000-0000-0000-0000-000000000015"), 10, 15, 20, 80 },
                    { new Guid("00000000-0000-0000-0000-000000000016"), 0, 0, 0, 2 },
                    { new Guid("00000000-0000-0000-0000-000000000017"), 20, 20, 0, 100 },
                    { new Guid("00000000-0000-0000-0000-000000000018"), 25, 25, 0, 120 },
                    { new Guid("00000000-0000-0000-0000-000000000019"), 50, 100, 0, 150 },
                    { new Guid("00000000-0000-0000-0000-000000000020"), 60, 120, 0, 180 },
                    { new Guid("00000000-0000-0000-0000-000000000021"), 70, 150, 0, 200 },
                    { new Guid("00000000-0000-0000-0000-000000000022"), 20, 30, 25, 30 },
                    { new Guid("00000000-0000-0000-0000-000000000023"), 15, 20, 25, 50 },
                    { new Guid("00000000-0000-0000-0000-000000000024"), 60, 60, 30, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000025"), 70, 80, 30, 0 }
                });

            migrationBuilder.InsertData(
                schema: "mas",
                table: "BuildingLevel",
                columns: new[] { "Id", "BuildingId", "BuildingTimeInSeconds", "Level", "ResourcesCostId", "ResourcesProductionPerMinuteId", "TrainingTimeShortenedPercentage" },
                values: new object[,]
                {
                    { new Guid("16125837-ec4a-4b4f-bbbd-68c9471a4f51"), new Guid("00000000-0000-0000-0000-000000000005"), 60, 1, new Guid("00000000-0000-0000-0000-000000000017"), null, 0 },
                    { new Guid("38fc9fcc-afb9-48d6-8e3f-a81ba8d7dd3d"), new Guid("00000000-0000-0000-0000-000000000004"), 60, 1, new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000014"), 0 },
                    { new Guid("4ea2116c-0a35-41e4-9c93-21f1ce22aa82"), new Guid("00000000-0000-0000-0000-000000000003"), 60, 1, new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000010"), 0 },
                    { new Guid("5e786cad-5ffc-4940-a69a-dc9239e51603"), new Guid("00000000-0000-0000-0000-000000000001"), 150, 2, new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000004"), 10 },
                    { new Guid("5fca090e-e803-456c-a532-f1bee2e87c6c"), new Guid("00000000-0000-0000-0000-000000000002"), 150, 2, new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000008"), 10 },
                    { new Guid("804375d3-04a1-408b-97d8-8c448acfbb8e"), new Guid("00000000-0000-0000-0000-000000000006"), 500, 3, new Guid("00000000-0000-0000-0000-000000000021"), null, 20 },
                    { new Guid("890d74cf-37bb-46b0-a071-eacf6bc7ee84"), new Guid("00000000-0000-0000-0000-000000000006"), 200, 2, new Guid("00000000-0000-0000-0000-000000000020"), null, 10 },
                    { new Guid("92c7a8ef-6110-4177-a2fc-1bb83371ff1a"), new Guid("00000000-0000-0000-0000-000000000005"), 150, 2, new Guid("00000000-0000-0000-0000-000000000018"), null, 10 },
                    { new Guid("d56c57ba-2a2f-458b-9213-2d63e59015e1"), new Guid("00000000-0000-0000-0000-000000000001"), 60, 1, new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), 0 },
                    { new Guid("de162c7a-9307-4cf6-9a01-0e94e2bf5a87"), new Guid("00000000-0000-0000-0000-000000000002"), 60, 1, new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000006"), 0 },
                    { new Guid("df31e482-7f26-40d2-93c4-f8666e94e431"), new Guid("00000000-0000-0000-0000-000000000004"), 150, 2, new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000016"), 10 },
                    { new Guid("ef72d412-d879-45ae-8bc9-b97f8b709595"), new Guid("00000000-0000-0000-0000-000000000006"), 90, 1, new Guid("00000000-0000-0000-0000-000000000019"), null, 0 },
                    { new Guid("f06bc579-79a4-422c-ba75-9edfa8408aba"), new Guid("00000000-0000-0000-0000-000000000003"), 150, 2, new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000012"), 10 }
                });

            migrationBuilder.InsertData(
                schema: "mas",
                table: "MilitaryUnit",
                columns: new[] { "Id", "Attack", "Defense", "IconUrl", "MinBarracksLevel", "Name", "TrainingCostId", "TrainingTimeInSeconds" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 10, 10, "http://localhost:4200/units/swordsman.svg", 2, "Swordsman", new Guid("00000000-0000-0000-0000-000000000022"), 10 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 15, 5, "http://localhost:4200/units/archer.svg", 1, "Archer", new Guid("00000000-0000-0000-0000-000000000023"), 15 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 20, 25, "http://localhost:4200/units/knight.svg", 1, "Knight", new Guid("00000000-0000-0000-0000-000000000024"), 40 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 40, 20, "http://localhost:4200/units/knight_on_horseback.svg", 3, "Knight on horseback", new Guid("00000000-0000-0000-0000-000000000025"), 60 }
                });

            migrationBuilder.InsertData(
                schema: "mas",
                table: "MilitaryUnitTrainableInBarracks",
                columns: new[] { "BuildingBarracksId", "MilitaryUnitId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000001") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000002") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000003") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Village_AvailableResourcesId",
                schema: "mas",
                table: "Village",
                column: "AvailableResourcesId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnit_TrainingCostId",
                schema: "mas",
                table: "MilitaryUnit",
                column: "TrainingCostId");

            migrationBuilder.CreateIndex(
                name: "IX_Assistant_VillageId",
                schema: "mas",
                table: "Assistant",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnitTrainableInBarracks_MilitaryUnitId",
                schema: "mas",
                table: "MilitaryUnitTrainableInBarracks",
                column: "MilitaryUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assistant_User_UserId",
                schema: "mas",
                table: "Assistant",
                column: "UserId",
                principalSchema: "mas",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assistant_Village_VillageId",
                schema: "mas",
                table: "Assistant",
                column: "VillageId",
                principalSchema: "mas",
                principalTable: "Village",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryUnit_Resources_TrainingCostId",
                schema: "mas",
                table: "MilitaryUnit",
                column: "TrainingCostId",
                principalSchema: "mas",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Village_Resources_AvailableResourcesId",
                schema: "mas",
                table: "Village",
                column: "AvailableResourcesId",
                principalSchema: "mas",
                principalTable: "Resources",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assistant_User_UserId",
                schema: "mas",
                table: "Assistant");

            migrationBuilder.DropForeignKey(
                name: "FK_Assistant_Village_VillageId",
                schema: "mas",
                table: "Assistant");

            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryUnit_Resources_TrainingCostId",
                schema: "mas",
                table: "MilitaryUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_Village_Resources_AvailableResourcesId",
                schema: "mas",
                table: "Village");

            migrationBuilder.DropTable(
                name: "MilitaryUnitTrainableInBarracks",
                schema: "mas");

            migrationBuilder.DropIndex(
                name: "IX_Village_AvailableResourcesId",
                schema: "mas",
                table: "Village");

            migrationBuilder.DropIndex(
                name: "IX_MilitaryUnit_TrainingCostId",
                schema: "mas",
                table: "MilitaryUnit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assistant",
                schema: "mas",
                table: "Assistant");

            migrationBuilder.DropIndex(
                name: "IX_Assistant_VillageId",
                schema: "mas",
                table: "Assistant");

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("16125837-ec4a-4b4f-bbbd-68c9471a4f51"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("38fc9fcc-afb9-48d6-8e3f-a81ba8d7dd3d"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("4ea2116c-0a35-41e4-9c93-21f1ce22aa82"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("5e786cad-5ffc-4940-a69a-dc9239e51603"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("5fca090e-e803-456c-a532-f1bee2e87c6c"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("804375d3-04a1-408b-97d8-8c448acfbb8e"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("890d74cf-37bb-46b0-a071-eacf6bc7ee84"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("92c7a8ef-6110-4177-a2fc-1bb83371ff1a"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("d56c57ba-2a2f-458b-9213-2d63e59015e1"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("de162c7a-9307-4cf6-9a01-0e94e2bf5a87"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("df31e482-7f26-40d2-93c4-f8666e94e431"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("ef72d412-d879-45ae-8bc9-b97f8b709595"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("f06bc579-79a4-422c-ba75-9edfa8408aba"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Location",
                keyColumns: new[] { "PositionX", "PositionY" },
                keyValues: new object[] { 0, 0 });

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Location",
                keyColumns: new[] { "PositionX", "PositionY" },
                keyValues: new object[] { 0, 1 });

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Location",
                keyColumns: new[] { "PositionX", "PositionY" },
                keyValues: new object[] { 1, 0 });

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Location",
                keyColumns: new[] { "PositionX", "PositionY" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Location",
                keyColumns: new[] { "PositionX", "PositionY" },
                keyValues: new object[] { 2, 0 });

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Location",
                keyColumns: new[] { "PositionX", "PositionY" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Location",
                keyColumns: new[] { "PositionX", "PositionY" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "MilitaryUnit",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "MilitaryUnit",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "MilitaryUnit",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "MilitaryUnit",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Building",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Building",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Building",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Building",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Building",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Building",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.DropColumn(
                name: "AvailableResourcesId",
                schema: "mas",
                table: "Village");

            migrationBuilder.DropColumn(
                name: "TrainingCostId",
                schema: "mas",
                table: "MilitaryUnit");

            migrationBuilder.DropColumn(
                name: "TrainingTimeInSeconds",
                schema: "mas",
                table: "MilitaryUnit");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "mas",
                table: "Assistant");

            migrationBuilder.RenameColumn(
                name: "VillageId",
                schema: "mas",
                table: "Assistant",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assistant",
                schema: "mas",
                table: "Assistant",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Assistant_User_Id",
                schema: "mas",
                table: "Assistant",
                column: "Id",
                principalSchema: "mas",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assistant_Village_Id",
                schema: "mas",
                table: "Assistant",
                column: "Id",
                principalSchema: "mas",
                principalTable: "Village",
                principalColumn: "Id");

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
    }
}
