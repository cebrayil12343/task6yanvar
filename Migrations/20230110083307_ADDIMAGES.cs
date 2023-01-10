using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5yanvardnm5.Migrations
{
    public partial class ADDIMAGES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "bookId",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "bookImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPoster = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookImages_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_bookId",
                table: "books",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_bookImages_BookId",
                table: "bookImages",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_books_bookId",
                table: "books",
                column: "bookId",
                principalTable: "books",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_books_bookId",
                table: "books");

            migrationBuilder.DropTable(
                name: "bookImages");

            migrationBuilder.DropIndex(
                name: "IX_books_bookId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "books");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "books");

            migrationBuilder.DropColumn(
                name: "bookId",
                table: "books");
        }
    }
}
