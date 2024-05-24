using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAndVillage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "mas");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "mas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Village",
                schema: "mas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CrestImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Village", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Village_User_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "mas",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assistant",
                schema: "mas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assistant_User_Id",
                        column: x => x.Id,
                        principalSchema: "mas",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assistant_Village_Id",
                        column: x => x.Id,
                        principalSchema: "mas",
                        principalTable: "Village",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Village_OwnerId",
                schema: "mas",
                table: "Village",
                column: "OwnerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assistant",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "Village",
                schema: "mas");

            migrationBuilder.DropTable(
                name: "User",
                schema: "mas");
        }
    }
}
