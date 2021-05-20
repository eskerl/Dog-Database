using Microsoft.EntityFrameworkCore.Migrations;

namespace DogDatabase.Migrations
{
    public partial class AddRanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "Age",
                table: "Dog",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Dog",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));
        }
    }
}
