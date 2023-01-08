using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5yanvardnm5.Migrations
{
    public partial class ImageMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "sliders",
                type: "nvarchar(136)",
                maxLength: 136,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "sliders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(136)",
                oldMaxLength: 136);
        }
    }
}
