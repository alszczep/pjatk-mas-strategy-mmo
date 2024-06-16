using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class FixMilitaryUnitsNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryUnitsInVillage_Village_VillageId1",
                schema: "mas",
                table: "MilitaryUnitsInVillage");

            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryUnitsQueue_Village_VillageId1",
                schema: "mas",
                table: "MilitaryUnitsQueue");

            migrationBuilder.DropIndex(
                name: "IX_MilitaryUnitsQueue_VillageId1",
                schema: "mas",
                table: "MilitaryUnitsQueue");

            migrationBuilder.DropIndex(
                name: "IX_MilitaryUnitsInVillage_VillageId1",
                schema: "mas",
                table: "MilitaryUnitsInVillage");

            migrationBuilder.DropColumn(
                name: "VillageId1",
                schema: "mas",
                table: "MilitaryUnitsQueue");

            migrationBuilder.DropColumn(
                name: "VillageId1",
                schema: "mas",
                table: "MilitaryUnitsInVillage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VillageId1",
                schema: "mas",
                table: "MilitaryUnitsQueue",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VillageId1",
                schema: "mas",
                table: "MilitaryUnitsInVillage",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnitsQueue_VillageId1",
                schema: "mas",
                table: "MilitaryUnitsQueue",
                column: "VillageId1");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnitsInVillage_VillageId1",
                schema: "mas",
                table: "MilitaryUnitsInVillage",
                column: "VillageId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryUnitsInVillage_Village_VillageId1",
                schema: "mas",
                table: "MilitaryUnitsInVillage",
                column: "VillageId1",
                principalSchema: "mas",
                principalTable: "Village",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryUnitsQueue_Village_VillageId1",
                schema: "mas",
                table: "MilitaryUnitsQueue",
                column: "VillageId1",
                principalSchema: "mas",
                principalTable: "Village",
                principalColumn: "Id");
        }
    }
}
