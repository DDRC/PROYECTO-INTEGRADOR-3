using Microsoft.EntityFrameworkCore.Migrations;

namespace TextilesMedicosJDJ.Migrations
{
    public partial class produccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Produccion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "MyProperty",
                table: "Produccion",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
