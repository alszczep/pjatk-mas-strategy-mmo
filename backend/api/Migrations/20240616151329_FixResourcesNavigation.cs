using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class FixResourcesNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Village_AvailableResourcesId",
                schema: "mas",
                table: "Village");

            migrationBuilder.DropIndex(
                name: "IX_MilitaryUnit_TrainingCostId",
                schema: "mas",
                table: "MilitaryUnit");

            migrationBuilder.DropIndex(
                name: "IX_BuildingLevel_ResourcesCostId",
                schema: "mas",
                table: "BuildingLevel");

            migrationBuilder.DropIndex(
                name: "IX_BuildingLevel_ResourcesProductionPerMinuteId",
                schema: "mas",
                table: "BuildingLevel");

            migrationBuilder.CreateIndex(
                name: "IX_Village_AvailableResourcesId",
                schema: "mas",
                table: "Village",
                column: "AvailableResourcesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryUnit_TrainingCostId",
                schema: "mas",
                table: "MilitaryUnit",
                column: "TrainingCostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingLevel_ResourcesCostId",
                schema: "mas",
                table: "BuildingLevel",
                column: "ResourcesCostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingLevel_ResourcesProductionPerMinuteId",
                schema: "mas",
                table: "BuildingLevel",
                column: "ResourcesProductionPerMinuteId",
                unique: true,
                filter: "[ResourcesProductionPerMinuteId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Village_AvailableResourcesId",
                schema: "mas",
                table: "Village");

            migrationBuilder.DropIndex(
                name: "IX_MilitaryUnit_TrainingCostId",
                schema: "mas",
                table: "MilitaryUnit");

            migrationBuilder.DropIndex(
                name: "IX_BuildingLevel_ResourcesCostId",
                schema: "mas",
                table: "BuildingLevel");

            migrationBuilder.DropIndex(
                name: "IX_BuildingLevel_ResourcesProductionPerMinuteId",
                schema: "mas",
                table: "BuildingLevel");

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
    }
}
