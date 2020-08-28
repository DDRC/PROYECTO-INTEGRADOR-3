using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TextilesMedicosJDJ.Migrations
{
    public partial class ventas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<float>(nullable: false),
                    Total = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ventas");
        }
    }
}
