using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Praktos.Migrations
{
    /// <inheritdoc />
    public partial class cxz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autors",
                columns: table => new
                {
                    Id_Autors = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autors", x => x.Id_Autors);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id_Genres = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id_Genres);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    Id_Readers = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactDetails = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.Id_Readers);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id_Books = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Autors = table.Column<int>(type: "int", nullable: false),
                    Id_Genre = table.Column<int>(type: "int", nullable: false),
                    AvailableCopies = table.Column<int>(type: "int", nullable: false),
                    YearOfPublication = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id_Books);
                    table.ForeignKey(
                        name: "FK_Books_Autors_Id_Autors",
                        column: x => x.Id_Autors,
                        principalTable: "Autors",
                        principalColumn: "Id_Autors",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_Id_Genre",
                        column: x => x.Id_Genre,
                        principalTable: "Genres",
                        principalColumn: "Id_Genres",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookRentalsHistory",
                columns: table => new
                {
                    Id_BookRentalHistory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Books = table.Column<int>(type: "int", nullable: false),
                    Id_Readers = table.Column<int>(type: "int", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRentalsHistory", x => x.Id_BookRentalHistory);
                    table.ForeignKey(
                        name: "FK_BookRentalsHistory_Books_Id_Books",
                        column: x => x.Id_Books,
                        principalTable: "Books",
                        principalColumn: "Id_Books",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRentalsHistory_Readers_Id_Readers",
                        column: x => x.Id_Readers,
                        principalTable: "Readers",
                        principalColumn: "Id_Readers",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRentalsHistory_Id_Books",
                table: "BookRentalsHistory",
                column: "Id_Books");

            migrationBuilder.CreateIndex(
                name: "IX_BookRentalsHistory_Id_Readers",
                table: "BookRentalsHistory",
                column: "Id_Readers");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Id_Autors",
                table: "Books",
                column: "Id_Autors");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Id_Genre",
                table: "Books",
                column: "Id_Genre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRentalsHistory");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "Autors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
