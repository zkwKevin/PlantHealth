using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoApi.Migrations
{
    public partial class version9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "TodoItems");

            migrationBuilder.AddColumn<int>(
                name: "Mode",
                table: "TodoItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModeValue",
                table: "TodoItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimesForMode",
                table: "TodoItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mode",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "ModeValue",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "TimesForMode",
                table: "TodoItems");

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "TodoItems",
                nullable: true);
        }
    }
}
