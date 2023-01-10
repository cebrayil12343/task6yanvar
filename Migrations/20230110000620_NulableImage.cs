using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5yanvardnm5.Migrations
{
    public partial class NulableImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "sliders",
                type: "nvarchar(136)",
                maxLength: 136,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(136)",
                oldMaxLength: 136);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "sliders",
                type: "nvarchar(136)",
                maxLength: 136,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(136)",
                oldMaxLength: 136,
                oldNullable: true);
        }
    }
}
