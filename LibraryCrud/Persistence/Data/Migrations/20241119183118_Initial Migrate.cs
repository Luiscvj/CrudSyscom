using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryCrud.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Birth = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_book_BookId",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenres",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => new { x.BookId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_BookGenres_book_BookId",
                        column: x => x.BookId,
                        principalTable: "book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenres_genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "AuthorId", "AuthorName", "Birth" },
                values: new object[,]
                {
                    { 1, "Gabriel Garcia Marquez", new DateTime(1927, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Isabel Allende", new DateTime(1942, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Jorge Luis Borges", new DateTime(1899, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Mario Vargas Llosa", new DateTime(1936, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Octavio Paz", new DateTime(1914, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "BookId", "BookTitle", "PublicationDate" },
                values: new object[,]
                {
                    { 1, "Cien Años de Soledad", new DateTime(1967, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "El Amor en los Tiempos del Cólera", new DateTime(1985, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "La Casa de los Espíritus", new DateTime(1982, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "De Amor y de Sombra", new DateTime(1984, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Ficciones", new DateTime(1944, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "El Aleph", new DateTime(1949, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "La Ciudad y los Perros", new DateTime(1963, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "La Fiesta del Chivo", new DateTime(2000, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "El Laberinto de la Soledad", new DateTime(1950, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Piedra de Sol", new DateTime(1957, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "genre",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { 1, "RealismoMagico" },
                    { 2, "Fantasia" },
                    { 3, "Ficcion" },
                    { 4, "NoFiccion" },
                    { 5, "Terror" },
                    { 6, "CienciaFiccion" },
                    { 7, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 5, 9 },
                    { 5, 10 }
                });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 7 },
                    { 2, 1 },
                    { 2, 7 },
                    { 3, 1 },
                    { 3, 7 },
                    { 4, 1 },
                    { 4, 7 },
                    { 5, 2 },
                    { 5, 3 },
                    { 6, 2 },
                    { 6, 3 },
                    { 7, 7 },
                    { 8, 7 },
                    { 9, 4 },
                    { 10, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_GenreId",
                table: "BookGenres",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "BookGenres");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "genre");
        }
    }
}
