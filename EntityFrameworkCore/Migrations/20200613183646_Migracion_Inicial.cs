using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false, defaultValue: 0),
                    nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    Ocupacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCurso = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    EstudianteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.CursoId);
                    table.ForeignKey(
                        name: "FK_Curso_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DireccionEstudiantes",
                columns: table => new
                {
                    direccionEstudianteId = table.Column<int>(nullable: false),
                    direccion = table.Column<string>(nullable: true),
                    ciudad = table.Column<string>(nullable: true),
                    provincia = table.Column<string>(nullable: true),
                    pais = table.Column<string>(nullable: true),
                    estudianteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionEstudiantes", x => x.direccionEstudianteId);
                    table.ForeignKey(
                        name: "FK_DireccionEstudiantes_Estudiantes_direccionEstudianteId",
                        column: x => x.direccionEstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursoEstudiantes",
                columns: table => new
                {
                    EstcursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudianteId = table.Column<int>(nullable: false),
                    EstudentesEstudianteId = table.Column<int>(nullable: true),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoEstudiantes", x => x.EstcursoId);
                    table.ForeignKey(
                        name: "FK_CursoEstudiantes_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoEstudiantes_Estudiantes_EstudentesEstudianteId",
                        column: x => x.EstudentesEstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "EstudianteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curso_EstudianteId",
                table: "Curso",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoEstudiantes_CursoId",
                table: "CursoEstudiantes",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoEstudiantes_EstudentesEstudianteId",
                table: "CursoEstudiantes",
                column: "EstudentesEstudianteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoEstudiantes");

            migrationBuilder.DropTable(
                name: "DireccionEstudiantes");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}
