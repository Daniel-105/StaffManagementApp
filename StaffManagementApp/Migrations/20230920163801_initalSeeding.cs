using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StaffManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class initalSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hobbies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Team A" },
                    { 2, "Team B" },
                    { 3, "Team C" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Birthday", "Email", "Hobbies", "ImageURL", "Name", "TeamId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao@gmail.com", "Thriatlon", null, "Joao", 1 },
                    { 2, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria@gmail.com", "Painting", null, "Maria", 2 },
                    { 3, new DateTime(1985, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos@gmail.com", "Cooking", null, "Carlos", 1 },
                    { 4, new DateTime(1988, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana@gmail.com", "Reading", null, "Ana", 2 },
                    { 5, new DateTime(1995, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "luis@gmail.com", "Gardening", null, "Luis", 3 },
                    { 6, new DateTime(1993, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "sofia@gmail.com", "Photography", null, "Sofia", 1 },
                    { 7, new DateTime(1991, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedro@gmail.com", "Swimming", null, "Pedro", 3 },
                    { 8, new DateTime(1987, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "marta@gmail.com", "Traveling", null, "Marta", 2 },
                    { 9, new DateTime(1998, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "rita@gmail.com", "Playing Guitar", null, "Rita", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_TeamId",
                table: "Staff",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
