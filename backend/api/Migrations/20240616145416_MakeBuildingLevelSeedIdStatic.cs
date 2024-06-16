using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class MakeBuildingLevelSeedIdStatic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingsQueue_BuildingInVillage_BuildingInVillageId1",
                schema: "mas",
                table: "BuildingsQueue");

            migrationBuilder.DropIndex(
                name: "IX_BuildingsQueue_BuildingInVillageId1",
                schema: "mas",
                table: "BuildingsQueue");

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

            migrationBuilder.DropColumn(
                name: "BuildingInVillageId1",
                schema: "mas",
                table: "BuildingsQueue");

            migrationBuilder.InsertData(
                schema: "mas",
                table: "BuildingLevel",
                columns: new[] { "Id", "BuildingId", "BuildingTimeInSeconds", "Level", "ResourcesCostId", "ResourcesProductionPerMinuteId", "TrainingTimeShortenedPercentage" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), 60, 1, new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000002"), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000001"), 150, 2, new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000004"), 10 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000002"), 60, 1, new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000006"), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000002"), 150, 2, new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000008"), 10 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000003"), 60, 1, new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000010"), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new Guid("00000000-0000-0000-0000-000000000003"), 150, 2, new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000012"), 10 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new Guid("00000000-0000-0000-0000-000000000004"), 60, 1, new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000014"), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new Guid("00000000-0000-0000-0000-000000000004"), 150, 2, new Guid("00000000-0000-0000-0000-000000000015"), new Guid("00000000-0000-0000-0000-000000000016"), 10 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new Guid("00000000-0000-0000-0000-000000000005"), 60, 1, new Guid("00000000-0000-0000-0000-000000000017"), null, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new Guid("00000000-0000-0000-0000-000000000005"), 150, 2, new Guid("00000000-0000-0000-0000-000000000018"), null, 10 },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new Guid("00000000-0000-0000-0000-000000000006"), 90, 1, new Guid("00000000-0000-0000-0000-000000000019"), null, 0 },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new Guid("00000000-0000-0000-0000-000000000006"), 200, 2, new Guid("00000000-0000-0000-0000-000000000020"), null, 10 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new Guid("00000000-0000-0000-0000-000000000006"), 500, 3, new Guid("00000000-0000-0000-0000-000000000021"), null, 20 }
                });

            migrationBuilder.UpdateData(
                schema: "mas",
                table: "MilitaryUnit",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "IconUrl",
                value: "http://localhost:4200/units/swordsman.bmp");

            migrationBuilder.UpdateData(
                schema: "mas",
                table: "MilitaryUnit",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "IconUrl",
                value: "http://localhost:4200/units/archer.bmp");

            migrationBuilder.UpdateData(
                schema: "mas",
                table: "MilitaryUnit",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "IconUrl",
                value: "http://localhost:4200/units/knight.bmp");

            migrationBuilder.UpdateData(
                schema: "mas",
                table: "MilitaryUnit",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "IconUrl",
                value: "http://localhost:4200/units/knight_on_horseback.bmp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                schema: "mas",
                table: "BuildingLevel",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.AddColumn<Guid>(
                name: "BuildingInVillageId1",
                schema: "mas",
                table: "BuildingsQueue",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.UpdateData(
                schema: "mas",
                table: "MilitaryUnit",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "IconUrl",
                value: "http://localhost:4200/units/swordsman.svg");

            migrationBuilder.UpdateData(
                schema: "mas",
                table: "MilitaryUnit",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "IconUrl",
                value: "http://localhost:4200/units/archer.svg");

            migrationBuilder.UpdateData(
                schema: "mas",
                table: "MilitaryUnit",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "IconUrl",
                value: "http://localhost:4200/units/knight.svg");

            migrationBuilder.UpdateData(
                schema: "mas",
                table: "MilitaryUnit",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                column: "IconUrl",
                value: "http://localhost:4200/units/knight_on_horseback.svg");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingsQueue_BuildingInVillageId1",
                schema: "mas",
                table: "BuildingsQueue",
                column: "BuildingInVillageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingsQueue_BuildingInVillage_BuildingInVillageId1",
                schema: "mas",
                table: "BuildingsQueue",
                column: "BuildingInVillageId1",
                principalSchema: "mas",
                principalTable: "BuildingInVillage",
                principalColumn: "Id");
        }
    }
}
