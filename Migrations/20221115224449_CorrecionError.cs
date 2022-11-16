using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpLabo4_usarEste_.Migrations
{
    public partial class CorrecionError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "TiendaWEbs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "TiendaWEbs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
