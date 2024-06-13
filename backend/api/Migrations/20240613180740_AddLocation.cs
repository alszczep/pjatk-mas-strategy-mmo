using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionX",
                schema: "mas",
                table: "Village",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionY",
                schema: "mas",
                table: "Village",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "mas",
                columns: table => new
                {
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionY = table.Column<int>(type: "int", nullable: false),
                    MilitaryUnitsDefensePercentageBonus = table.Column<int>(type: "int", nullable: false),
                    GoldProductionBonus = table.Column<int>(type: "int", nullable: true),
                    AllResourcesProductionPercentageLoss = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => new { x.PositionX, x.PositionY });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Village_PositionX_PositionY",
                schema: "mas",
                table: "Village",
                columns: new[] { "PositionX", "PositionY" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Village_Location_PositionX_PositionY",
                schema: "mas",
                table: "Village",
                columns: new[] { "PositionX", "PositionY" },
                principalSchema: "mas",
                principalTable: "Location",
                principalColumns: new[] { "PositionX", "PositionY" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Village_Location_PositionX_PositionY",
                schema: "mas",
                table: "Village");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "mas");

            migrationBuilder.DropIndex(
                name: "IX_Village_PositionX_PositionY",
                schema: "mas",
                table: "Village");

            migrationBuilder.DropColumn(
                name: "PositionX",
                schema: "mas",
                table: "Village");

            migrationBuilder.DropColumn(
                name: "PositionY",
                schema: "mas",
                table: "Village");
        }
    }
}
