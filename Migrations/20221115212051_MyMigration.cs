using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tpLabo4_usarEste_.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMarca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SistemaOperativo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaOperativo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TiendaWEbs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreTienda = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiendaWEbs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Celular",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    marcaId = table.Column<int>(type: "int", nullable: false),
                    sistemaOperativoId = table.Column<int>(type: "int", nullable: false),
                    TiendaWEbid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celular", x => x.id);
                    table.ForeignKey(
                        name: "FK_Celular_Marca_marcaId",
                        column: x => x.marcaId,
                        principalTable: "Marca",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Celular_SistemaOperativo_sistemaOperativoId",
                        column: x => x.sistemaOperativoId,
                        principalTable: "SistemaOperativo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Celular_TiendaWEbs_TiendaWEbid",
                        column: x => x.TiendaWEbid,
                        principalTable: "TiendaWEbs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombreproovedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiendaWEbid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.id);
                    table.ForeignKey(
                        name: "FK_Proveedor_TiendaWEbs_TiendaWEbid",
                        column: x => x.TiendaWEbid,
                        principalTable: "TiendaWEbs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Celular_marcaId",
                table: "Celular",
                column: "marcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Celular_sistemaOperativoId",
                table: "Celular",
                column: "sistemaOperativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Celular_TiendaWEbid",
                table: "Celular",
                column: "TiendaWEbid");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_TiendaWEbid",
                table: "Proveedor",
                column: "TiendaWEbid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Celular");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "SistemaOperativo");

            migrationBuilder.DropTable(
                name: "TiendaWEbs");
        }
    }
}
