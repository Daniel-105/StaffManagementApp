using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StaffManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class createDataBaseAndInitialSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hobbies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Birthday", "Email", "Hobbies", "ImageURL", "Name", "Team" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao@gmail.com", "Thriatlon", null, "Joao", "A" },
                    { 2, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria@gmail.com", "Painting", null, "Maria", "B" },
                    { 3, new DateTime(1985, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos@gmail.com", "Cooking", null, "Carlos", "A" },
                    { 4, new DateTime(1988, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana@gmail.com", "Reading", null, "Ana", "B" },
                    { 5, new DateTime(1995, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "luis@gmail.com", "Gardening", null, "Luis", "C" },
                    { 6, new DateTime(1993, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "sofia@gmail.com", "Photography", null, "Sofia", "A" },
                    { 7, new DateTime(1991, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedro@gmail.com", "Swimming", null, "Pedro", "C" },
                    { 8, new DateTime(1987, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "marta@gmail.com", "Traveling", null, "Marta", "B" },
                    { 9, new DateTime(1998, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "rita@gmail.com", "Playing Guitar", null, "Rita", "A" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
