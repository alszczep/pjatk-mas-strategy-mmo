using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingColumnsForBuildingInVillage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrainingTimeShortenedInSeconds",
                schema: "mas",
                table: "BuildingLevel",
                newName: "TrainingTimeShortenedPercentage");

            migrationBuilder.AddCheckConstraint(
                name: "CK_BuildingLevel_TrainingTimeShortenedPercentage",
                schema: "mas",
                table: "BuildingLevel",
                sql: "TrainingTimeShortenedPercentage >= 0 AND TrainingTimeShortenedPercentage < 100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_BuildingInVillage_BuildingSpot",
                schema: "mas",
                table: "BuildingInVillage",
                sql: "BuildingSpot >= 0 AND BuildingSpot <= 9");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_BuildingLevel_TrainingTimeShortenedPercentage",
                schema: "mas",
                table: "BuildingLevel");

            migrationBuilder.DropCheckConstraint(
                name: "CK_BuildingInVillage_BuildingSpot",
                schema: "mas",
                table: "BuildingInVillage");

            migrationBuilder.RenameColumn(
                name: "TrainingTimeShortenedPercentage",
                schema: "mas",
                table: "BuildingLevel",
                newName: "TrainingTimeShortenedInSeconds");
        }
    }
}
