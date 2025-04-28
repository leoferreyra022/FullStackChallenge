using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Platform = table.Column<string>(type: "longtext", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "FinishDate", "Platform", "State", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Udemy", 0, "Introduction to C#" },
                    { 2, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pluralsight", 0, "Advanced .NET Development" },
                    { 3, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "LinkedIn Learning", 2, "Entity Framework Core Mastery" },
                    { 4, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coursera", 0, "Mastering ASP.NET Core" },
                    { 5, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Udemy", 0, "C# Design Patterns" },
                    { 6, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pluralsight", 2, "Clean Code Principles" },
                    { 7, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "LinkedIn Learning", 0, "Microservices with .NET" },
                    { 8, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Udemy", 0, "Blazor WebAssembly Fundamentals" },
                    { 9, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pluralsight", 2, "Testing in .NET" },
                    { 10, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coursera", 0, "Azure for .NET Developers" },
                    { 11, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LinkedIn Learning", 0, "Dependency Injection in .NET" },
                    { 12, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Udemy", 0, "LINQ Mastery" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
