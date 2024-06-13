using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationCheckConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Location_AllResourcesProductionPercentageLoss",
                schema: "mas",
                table: "Location",
                sql: "AllResourcesProductionPercentageLoss >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Location_GoldProductionBonus",
                schema: "mas",
                table: "Location",
                sql: "GoldProductionBonus >= 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Location_MilitaryUnitsDefensePercentageBonus",
                schema: "mas",
                table: "Location",
                sql: "MilitaryUnitsDefensePercentageBonus >= 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Location_AllResourcesProductionPercentageLoss",
                schema: "mas",
                table: "Location");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Location_GoldProductionBonus",
                schema: "mas",
                table: "Location");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Location_MilitaryUnitsDefensePercentageBonus",
                schema: "mas",
                table: "Location");
        }
    }
}
