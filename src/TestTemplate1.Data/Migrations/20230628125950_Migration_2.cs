using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTemplate1.Data.Migrations
{
    public partial class Migration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SomeNumber",
                table: "Foos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SomeNumber",
                table: "Foos");
        }
    }
}
