using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5yanvardnm5.Migrations
{
    public partial class Bookiddelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_books_bookId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_bookId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "bookId",
                table: "books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bookId",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_books_bookId",
                table: "books",
                column: "bookId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_books_bookId",
                table: "books",
                column: "bookId",
                principalTable: "books",
                principalColumn: "Id");
        }
    }
}
